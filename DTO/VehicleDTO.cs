namespace CarInspectionAPI.DTO
{
    public class VehicleDTO
    {
        public string? CarRegistrationNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public DateTime DateOfInspection { get; set; }
        public DateTime NextInspectionDate { get; set; }
        public bool IsOperational { get; set; }
        public bool IsInspectionExpired => DateTime.Now > NextInspectionDate;
    }
}
