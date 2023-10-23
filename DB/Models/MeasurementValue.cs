namespace App.DB.Models
{
    public class MeasurementValue
    {
        public int ID { get; set;}
        public int MeasurementID { get; set; }
        public Measurement? Measurement { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
