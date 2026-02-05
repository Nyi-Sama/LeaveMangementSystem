using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveMangementSystem.Web.Data;
using LeaveMangementSystem.Web.Models.LeaveType;
using AutoMapper;

namespace LeaveMangementSystem.Web.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static string NameExistMsg = "Leave Type already exists!";

        public LeaveTypesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var data = await _context.leaveTypes.ToListAsync();

            // instead of manually mapping data, use auto mapper
            //var viewData = data.Select(d => new IndexVM
            //{
            //    Id = d.Id,
            //    Name = d.Name,
            //    NumberOfDays = d.NumberOfDays,
            //});

            // this is autoMapper
            var viewData = _mapper.Map<List<IndexVM>>(data);

            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);

            if (leaveType == null)
            {
                return NotFound();
            }

            var DetailsData = _mapper.Map<DetailsVM>(leaveType);

            return View(DetailsData);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVM createdLeaveType)
        {
            if (await IsExistedName(createdLeaveType.Name))
            {
                ModelState.AddModelError(nameof(createdLeaveType.Name), NameExistMsg);
            }

            if (ModelState.IsValid)
            {
                var leaveType = _mapper.Map<LeaveType>(createdLeaveType);
                _context.Add(leaveType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(createdLeaveType);
        }

        // GET: LeaveTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes.FindAsync(id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var editData = _mapper.Map<EditVM>(leaveType);

            return View(editData);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditVM editedData)
        {
            if (id != editedData.Id)
            {
                return NotFound();
            }

            if (await IsExistedNameForEdit(editedData))
            {
                ModelState.AddModelError(nameof(editedData.Name), NameExistMsg);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var leaveType = _mapper.Map<LeaveType>(editedData);
                    _context.Update(leaveType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(editedData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(editedData);
        }

        // GET: LeaveTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveType = await _context.leaveTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            var deleteData = _mapper.Map<DeleteVM>(leaveType);

            return View(deleteData);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveType = await _context.leaveTypes.FindAsync(id);
            if (leaveType != null)
            {
                _context.leaveTypes.Remove(leaveType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(int id)
        {
            return _context.leaveTypes.Any(e => e.Id == id);
        }

        private async Task<bool> IsExistedName(string name)
        {
            string lowerCaseName = name.ToLower();
            return await _context.leaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName));
        }

        private async Task<bool> IsExistedNameForEdit(EditVM data)
        {
            string lowerCaseName = data.Name.ToLower();
            return await _context.leaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowerCaseName) && q.Id != data.Id);
        }
    }
}
