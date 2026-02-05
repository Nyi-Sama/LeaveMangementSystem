using System.ComponentModel.DataAnnotations;

namespace LeaveMangementSystem.Web.Models.LeaveType
{
    public class CreateVM
    {
        [Required]
        [Length(4, 150, ErrorMessage = "Wrong Input")]
        public string Name { get; set; }

        [Display(Name = "Days")]
        [Range(10, 99)]
        public int NumberOfDays { get; set; }
    }
}
