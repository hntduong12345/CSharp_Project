using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.DTOs
{
    public class FootballPlayerDTO
    {
        [Required(ErrorMessage = "FootballPlayerId is required.")]
        public string FootballPlayerId { get; set; } = null!;

        [Required(ErrorMessage = "FullName is required.")]
        [RegularExpression("^[A-Za-z0-9 @#]+$", ErrorMessage = "Invalid PaintingName format")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Achievements is required.")]
        public string Achievements { get; set; } = null!;

        [Required(ErrorMessage = "Birthday is required.")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "PlayerExperiences is required.")]
        public string PlayerExperiences { get; set; } = null!;

        [Required(ErrorMessage = "Nomination is required.")]
        public string Nomination { get; set; } = null!;

        [Required(ErrorMessage = "FootballClubId is required.")]
        public string? FootballClubId { get; set; }
    }

    public class UpdateFootballPlayerDTO
    {
        [Required(ErrorMessage = "FullName is required.")]
        [RegularExpression("^[A-Za-z0-9 ]+$", ErrorMessage = "Invalid PaintingName format")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "Achievements is required.")]
        public string Achievements { get; set; } = null!;

        [Required(ErrorMessage = "Birthday is required.")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "PlayerExperiences is required.")]
        public string PlayerExperiences { get; set; } = null!;

        [Required(ErrorMessage = "Nomination is required.")]
        public string Nomination { get; set; } = null!;

        [Required(ErrorMessage = "FootballClubId is required.")]
        public string? FootballClubId { get; set; }
    }
}
