using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.DB.Models
{
    public class Measurement
    {
        public int ID { get; set; }
        [DisplayName("Measurement Name")]
        public string MeasureName { get; set; } = string.Empty;
        [DisplayName("Measurement Date")]
        public DateTime MeasureDate { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surename { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        [DisplayName("Subject Number")]
        public uint SubjectNumber { get; set; }

        public List<MeasurementValue>? Values { get; set; } = new();
    }
}
