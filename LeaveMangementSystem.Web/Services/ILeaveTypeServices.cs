using LeaveMangementSystem.Web.Models.LeaveType;

namespace LeaveMangementSystem.Web.Services
{
    public interface ILeaveTypeServices
    {
        Task Create(CreateVM model);
        Task Edit(EditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<IndexVM>> GetAllLeaveTypes();
        Task<bool> IsExistedName(string name);
        Task<bool> IsExistedNameForEdit(EditVM data);
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}