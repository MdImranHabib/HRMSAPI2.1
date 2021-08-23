using System.ComponentModel.DataAnnotations;

namespace HRMSAPI.Models
{
    public class Flat
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        public double Rent { get; set; }

        [Required]
        [StringLength(50)]
        public string MeterNo { get; set; }

        public bool Status { get; set; }
    }    
}
