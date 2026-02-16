using AutoMapper;
using LeaveMangementSystem.Web.Data;
using LeaveMangementSystem.Web.Models.LeaveType;
using Microsoft.EntityFrameworkCore;

namespace LeaveMangementSystem.Web.Services;

public class LeaveTypeServices(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypeServices
{
    public async Task<List<IndexVM>> GetAllLeaveTypes()
    {
        var data = await _context.leaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<IndexVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.leaveTypes.FirstOrDefaultAsync(m => m.Id == id);

        if (data == null)
        {
            return null;
        }

        var ViewData = _mapper.Map<T>(data);
        return ViewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.leaveTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (data != null)
        {
            _context.leaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Create(CreateVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(EditVM model)
    {
        var leaveType = _mapper.Map<LeaveType>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public bool LeaveTypeExists(int id)
    {
        return _context.leaveTypes.Any(e => e.Id == id);
    }

    public async Task<bool> IsExistedName(string name)
    {
        string lowerCaseName = name.ToLower();
        return await _context.leaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName));
    }

    public async Task<bool> IsExistedNameForEdit(EditVM data)
    {
        string lowerCaseName = data.Name.ToLower();
        return await _context.leaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName) && q.Id != data.Id);

    }
}
