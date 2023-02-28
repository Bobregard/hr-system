using HrSystem.DataAccess.Repository.Interfaces;
using HrSystem.Models;
using HrSystem.VIewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HrSystem.Areas.Hr.Controllers
{
    [Area("Hr")]
    public class JobsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var jobs = _unitOfWork.JobRepository.GetAll();
            return View(jobs);
        }

        public IActionResult Upsert(int? id)
        {
            var jobVM = new JobViewModel
            {
                Job = new(),
                CategoriesList = _unitOfWork.CategoryRepository.GetAll().Select(
                    c => new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    }),
                CompaniesList = _unitOfWork.CompanyRepository.GetAll().Select(
                    c => new SelectListItem()
                    {
                        Text = c.Name,
                        Value = c.Id.ToString()
                    })
            };
            if (id == null || id == 0)
            {
                return View(jobVM);
            }
            else
            {

            }

            return View(jobVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(JobViewModel vm)
        {
            var existingJob = _unitOfWork.JobRepository.GetFirstOrDefault(c => c.Title == vm.Job.Title);
            if (existingJob != null)
            {
                ModelState.AddModelError("title", "Job with this title already exists");
            }
            
            if (ModelState.IsValid)
            {
                _unitOfWork.JobRepository.Update(vm.Job);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => id == c.Id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _unitOfWork.CategoryRepository.GetFirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }

    }
}
