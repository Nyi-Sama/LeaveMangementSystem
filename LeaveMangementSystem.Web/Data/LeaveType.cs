using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaveMangementSystem.Web.Data
{
    public class LeaveType
    {
        public int Id { get; set; }

        [Display(Name = "Type your leave name")]
        [Column(TypeName = "nvarchar(150)")]
        public string Name { get; set; }

        public int NumberOfDays { get; set; }
    }
}
