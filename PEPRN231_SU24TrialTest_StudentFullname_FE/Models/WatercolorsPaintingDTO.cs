using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class WatercolorsPaintingDTO
    {
        [Required(ErrorMessage = "PaintingId is required.")]
        public string PaintingId { get; set; } = null!;

        [Required(ErrorMessage = "PaintingName is required.")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Invalid PaintingName format")]
        public string PaintingName { get; set; } = null!;

        [Required(ErrorMessage = "PaintingDescription is required.")]
        public string? PaintingDescription { get; set; }

        [Required(ErrorMessage = "PaintingAuthor is required.")]
        public string? PaintingAuthor { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be >= 0")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "PublishYear is required.")]
        [Range(1000, int.MaxValue, ErrorMessage = "Publish Year >= 1000")]
        public int? PublishYear { get; set; }

        [Required(ErrorMessage = "CreatedDate is required.")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "StyleId is required.")]
        public string? StyleId { get; set; }
    }
}
