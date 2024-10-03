

namespace CarInspectionAPI.Models
{
    public class TechnicalTest
    {
        public int TestId { get; set; }
        public string? CarRegistrationNumber { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime DateOfInspection { get; set; }
        public DateTime NextInspectionDate { get; set; }
        public bool IsOperational { get; set; }
    }

}
