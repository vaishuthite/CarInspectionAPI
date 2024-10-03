namespace CarInspectionAPI.Models
{
    public class Vehicle
    {
        public string? CarRegistrationNumber { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        //public ICollection<TechnicalTest> TechnicalTests { get; set; }

        // List of Technical Tests
        public List<TechnicalTest> TechnicalTests { get; set; }

        public Vehicle()
        {
            // Initialize the TechnicalTests list to avoid null reference
            TechnicalTests = new List<TechnicalTest>();
        }
    }
}
