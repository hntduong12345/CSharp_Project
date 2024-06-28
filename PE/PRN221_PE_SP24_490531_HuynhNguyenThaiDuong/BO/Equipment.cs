using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public partial class Equipment
    {
        [Required(ErrorMessage = "Id is Required.")]
        public int EqId { get; set; }

        [Required(ErrorMessage = "Code is Required.")]
        public string EqCode { get; set; } = null!;

        [Required(ErrorMessage = "Name is Required.")]
        [MaxLength(10)]
        public string? EqName { get; set; }

        [Required(ErrorMessage = "Description is Required.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Model is Required.")]
        public string? Model { get; set; }

        [Required(ErrorMessage = "SupplierName is Required.")]
        public string? SupplierName { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessage = "Quantity is Required.")]
        [Range(1, 100, ErrorMessage = "Quantity is out of limit (Limit: 0 -> 100)")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Status is Required.")]
        public int? Status { get; set; }

        [Required(ErrorMessage = "Room is Required.")]
        public int? RoomId { get; set; }

        public virtual Room? Room { get; set; }
    }
}
