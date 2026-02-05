using System.ComponentModel.DataAnnotations;

namespace LeaveMangementSystem.Web.Models.LeaveType
{
    public class IndexVM : BaseLeaveTypeVM
    {
        public string Name { get; set; }

        [Display(Name = "Days")]
        public int NumberOfDays { get; set; }
    }
}
