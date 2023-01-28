using Difficulty_Learning.Models;
using Difficulty_Learning.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.Controllers
{
    public class Category_CourseController : Controller
    {
        // GET: Category_CourseController
        
        private readonly IDifficultyLearningRepository<Category_Course> CategoryCourseRepository;

        public Category_CourseController(IDifficultyLearningRepository<Category_Course> CategoryCourseRepository)
        {
            this.CategoryCourseRepository = CategoryCourseRepository;
        }      
        public ActionResult Index()
        {
            var _var = CategoryCourseRepository.List();
            return View(_var);
        }

        // GET: Category_CourseController/Details/5
        public ActionResult Details(int id)
        {
            var _var = CategoryCourseRepository.Find(id);
            return View(_var);
        }

        // GET: Category_CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category_Course collection)
        {
            try
            {
                CategoryCourseRepository.Add(collection);
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
            var _var = CategoryCourseRepository.Find(id);
            return View(_var);
        }

        // POST: Category_CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category_Course collection)
        {
            try
            {
                CategoryCourseRepository.Update(id, collection);
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
            var _var = CategoryCourseRepository.Find(id);
            return View(_var);
        }

        // POST: Category_CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category_Course collection)
        {
            try
            {
                CategoryCourseRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
