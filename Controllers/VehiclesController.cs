
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using CarInspectionAPI.DATA;
using CarInspectionAPI.DTO;
using CarInspectionAPI.Models;

namespace CarInspectionAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly CarInspectionContext _context;
        private readonly IMapper _mapper;

        public VehiclesController(CarInspectionContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/vehicles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetVehicles()
        {
            var vehicles = await _context.Vehicles.Include(v => v.TechnicalTests).ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VehicleDTO>>(vehicles));
        }

        // GET: api/vehicles/{registrationNumber}
        [HttpGet("{registrationNumber}")]
        public async Task<ActionResult<VehicleDTO>> GetVehicle(string registrationNumber)
        {
            var vehicle = await _context.Vehicles.Include(v => v.TechnicalTests)
                                                 .FirstOrDefaultAsync(v => v.CarRegistrationNumber == registrationNumber);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleDTO>(vehicle));
        }

        // POST: api/vehicles
        [HttpPost]
        public async Task<ActionResult> UpdateVehicles([FromBody] List<VehicleDTO> vehicleDTOs)
        {
            foreach (var vehicleDTO in vehicleDTOs)
            {
                var vehicle = await _context.Vehicles.Include(v => v.TechnicalTests)
                                                     .FirstOrDefaultAsync(v => v.CarRegistrationNumber == vehicleDTO.CarRegistrationNumber);

                if (vehicle == null)
                {
                    vehicle = new Vehicle
                    {
                        CarRegistrationNumber = vehicleDTO.CarRegistrationNumber,
                        Brand = vehicleDTO.Brand,
                        Model = vehicleDTO.Model
                    };
                    _context.Vehicles.Add(vehicle);
                }

                var technicalTest = new TechnicalTest
                {
                    CarRegistrationNumber = vehicleDTO.CarRegistrationNumber,
                    DateOfInspection = vehicleDTO.DateOfInspection,
                    NextInspectionDate = vehicleDTO.NextInspectionDate,
                    IsOperational = vehicleDTO.IsOperational
                };

                if (vehicle.TechnicalTests == null)
                {
                    vehicle.TechnicalTests = new List<TechnicalTest>();
                }
                vehicle.TechnicalTests.Add(technicalTest);
            }

            await _context.SaveChangesAsync();
            return Ok();
        }


     

    }
}