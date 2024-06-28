using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public partial class Eyeglass
    {
        [Required(ErrorMessage = "Id is required!")]
        public int EyeglassesId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        public string EyeglassesName { get; set; } = null!;

        [Required(ErrorMessage = "Description is required!")]
        public string? EyeglassesDescription { get; set; }

        [Required(ErrorMessage = "Frame Color is required!")]
        public string? FrameColor { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Quantity is required!")]
        public int? Quantity { get; set; }

        [DefaultValue(true)]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Len Type is required!")]
        public string? LensTypeId { get; set; }

        public virtual LensType? LensType { get; set; }
    }
}
