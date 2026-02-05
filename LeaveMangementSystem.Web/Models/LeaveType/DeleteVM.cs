using System.ComponentModel.DataAnnotations;

namespace LeaveMangementSystem.Web.Models.LeaveType
{
    public class DeleteVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days")]
        public int NumberOfDays { get; set; }
    }
}
