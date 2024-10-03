using AutoMapper;
using CarInspectionAPI.DTO;
using CarInspectionAPI.Models;

namespace CarInspectionAPI
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //CreateMap<Vehicle, VehicleDTO>()
            //     .ForMember(dest => dest.DateOfInspection, opt => opt.MapFrom(src => src.TechnicalTests.OrderByDescending(t => t.DateOfInspection).FirstOrDefault().DateOfInspection))
            //     .ForMember(dest => dest.NextInspectionDate, opt => opt.MapFrom(src => src.TechnicalTests.OrderByDescending(t => t.NextInspectionDate).FirstOrDefault().NextInspectionDate))
            //     .ForMember(dest => dest.IsOperational, opt => opt.MapFrom(src => src.TechnicalTests.OrderByDescending(t => t.DateOfInspection).FirstOrDefault().IsOperational));

            //CreateMap<VehicleDTO, Vehicle>();
            CreateMap<Vehicle, VehicleDTO>()
              .ForMember(dest => dest.DateOfInspection, opt => opt.MapFrom(src => src.TechnicalTests.OrderByDescending(t => t.DateOfInspection).FirstOrDefault().DateOfInspection))
    .ForMember(dest => dest.NextInspectionDate, opt => opt.MapFrom(src => src.TechnicalTests.OrderByDescending(t => t.NextInspectionDate).FirstOrDefault().NextInspectionDate))
    .ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<TechnicalTest, TechnicalTestDTO>().ReverseMap();

            // TechnicalTest to TechnicalTestDTO and vice versa
            //CreateMap<TechnicalTest, TechnicalTestDTO>();
            //CreateMap<TechnicalTestDTO, TechnicalTest>();
        }
    }
}
