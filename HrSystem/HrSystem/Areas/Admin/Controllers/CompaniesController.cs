using HrSystem.DataAccess.Repository.Interfaces;
using HrSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Collections;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HrSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CompaniesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompaniesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var companies = _unitOfWork.CompanyRepository.GetAll();
            return View(companies);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            var existingCompany = _unitOfWork.CompanyRepository.GetFirstOrDefault(c => c.Name == company.Name);
            if (existingCompany != null)
            {
                ModelState.AddModelError("name", "Company with this name already exists");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.CompanyRepository.Add(company);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var company = _unitOfWork.CompanyRepository.GetFirstOrDefault(c => id == c.Id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CompanyRepository.Update(company);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var company = _unitOfWork.CompanyRepository.GetFirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var company = _unitOfWork.CompanyRepository.GetFirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            _unitOfWork.CompanyRepository.Remove(company);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
