namespace CarInspectionAPI.DTO
{
    public class TechnicalTestDTO
    {
        public DateTime DateOfInspection { get; set; }
        public DateTime NextInspectionDate { get; set; }
        public bool IsOperational { get; set; }
        public bool IsInspectionExpired => DateTime.Now > NextInspectionDate;
    }
}
