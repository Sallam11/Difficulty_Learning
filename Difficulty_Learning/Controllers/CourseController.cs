using Difficulty_Learning.Models;
using Difficulty_Learning.Models.Repositories;
using Difficulty_Learning.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.Controllers
{
    public class CourseController : Controller
    {
        // GET: Category_CourseController
        
        private readonly IDifficultyLearningRepository<Course> CourseRepository;
        private readonly IDifficultyLearningRepository<Category_Course> _category_CourseRepository;
        private readonly IHostingEnvironment hosting;

        public CourseController(IDifficultyLearningRepository<Course> CourseRepository, IDifficultyLearningRepository<Category_Course> Category_CourseRepository,
             IHostingEnvironment hosting)
        {
            this.CourseRepository = CourseRepository;
            this._category_CourseRepository = Category_CourseRepository;
              this.hosting = hosting;
        }      
        public ActionResult Index()
        {
            var _var = CourseRepository.List();
            return View(_var);
        }

        // GET: Category_CourseController/Details/5
        public ActionResult Details(int id)
        {
            var _var = CourseRepository.Find(id);
            return View(_var);
        }

        // GET: Category_CourseController/Create
        public ActionResult Create()
        {
            var model = new CategoryViewModel
            {
                Categorys = _category_CourseRepository.List().ToList()
            };

            return View(model);
        }

        // POST: Category_CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel model)
        {
            try
            {
                string fileName = UploadFile(model.File1) ?? string.Empty;
                var _var = _category_CourseRepository.Find(model.Course_CategoryID);
                Course book = new Course
                {
                    Course_UserID = 5,
                    Course_CategoryID = _var.CategoryCourse_ID,
                    Course_Name = model.Course_Name,
                    Course_Path = fileName
                };
                CourseRepository.Add(book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category_CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            var _var = CourseRepository.Find(id);

            var Course_CategoryID = _var.Course_CategoryID == null ? _var.Course_CategoryID = 0 : _var.Course_CategoryID;
            var viewModel = new CategoryViewModel
            {
                Course_ID = _var.Course_ID,
                Course_Name = _var.Course_Name,
                Course_Path = _var.Course_Path,
                Course_CategoryID = _var.Course_CategoryID,
                Course_UserID = _var.Course_UserID,
                Categorys = _category_CourseRepository.List().ToList()
            };

            return View(viewModel);
        }

        // POST: Category_CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel viewModel)
        {
            try
            {

                string fileName = UploadFile(viewModel.File1, viewModel.Course_Path);

                var _var = CourseRepository.Find(viewModel.Course_ID);
                Course book = new Course
                {
                    Course_UserID = 5,
                    Course_CategoryID = _var.Course_CategoryID,
                    Course_Name = _var.Course_Name,
                    Course_Path = fileName
                };

                CourseRepository.Update(_var.Course_ID, book);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category_CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            var _var = CourseRepository.Find(id);
            return View(_var);
        }

        // POST: Category_CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Course collection)
        {
            try
            {
                CourseRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        string UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                string fullPath = Path.Combine(uploads, file.FileName);
                file.CopyTo(new FileStream(fullPath, FileMode.Create));

                return file.FileName;
            }

            return null;
        }

        string UploadFile(IFormFile file, string imageUrl)
        {
            if (file != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");

                string newPath = Path.Combine(uploads, file.FileName);
                string oldPath = Path.Combine(uploads, imageUrl);

                if (oldPath != newPath)
                {
                    System.IO.File.Delete(oldPath);
                    file.CopyTo(new FileStream(newPath, FileMode.Create));
                }

                return file.FileName;
            }

            return imageUrl;
        }
    }
}
