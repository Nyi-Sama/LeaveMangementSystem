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
using LeaveMangementSystem.Web.Services;

namespace LeaveMangementSystem.Web.Controllers
{
    [Authorize(Roles = RoleConstants.Administrator)]
    public class LeaveTypesController(ILeaveTypeServices _ILeaveTypeServices) : Controller
    {
        private static string NameExistMsg = "Leave Type already exists!";

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            var viewData = await _ILeaveTypeServices.GetAllLeaveTypes();
            return View(viewData);
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var leaveType = await _ILeaveTypeServices.Get<DetailsVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
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
            if (await _ILeaveTypeServices.IsExistedName(createdLeaveType.Name))
            {
                ModelState.AddModelError(nameof(createdLeaveType.Name), NameExistMsg);
            }

            if (ModelState.IsValid)
            {
                await _ILeaveTypeServices.Create(createdLeaveType);
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

            var leaveType = await _ILeaveTypeServices.Get<EditVM>(id.Value);

            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
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

            if (await _ILeaveTypeServices.IsExistedNameForEdit(editedData))
            {
                ModelState.AddModelError(nameof(editedData.Name), NameExistMsg);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ILeaveTypeServices.Edit(editedData);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ILeaveTypeServices.LeaveTypeExists(editedData.Id))
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

            var leaveType = await _ILeaveTypeServices.Get<DeleteVM>(id.Value);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ILeaveTypeServices.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
