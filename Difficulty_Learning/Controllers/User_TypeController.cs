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
    public class User_TypeController : Controller
    {
        // GET: Category_CourseController
        
        private readonly IDifficultyLearningRepository<User_Type> User_TypeRepository;

        public User_TypeController(IDifficultyLearningRepository<User_Type> User_TypeRepository)
        {
            this.User_TypeRepository = User_TypeRepository;
        }      
        public ActionResult Index()
        {
            var _var = User_TypeRepository.List();
            return View(_var);
        }

        // GET: Category_CourseController/Details/5
        public ActionResult Details(int id)
        {
            var _var = User_TypeRepository.Find(id);
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
        public ActionResult Create(User_Type collection)
        {
            try
            {
                User_TypeRepository.Add(collection);
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
            var _var = User_TypeRepository.Find(id);
            return View(_var);
        }

        // POST: Category_CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User_Type collection)
        {
            try
            {
                User_TypeRepository.Update(id, collection);
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
            var _var = User_TypeRepository.Find(id);
            return View(_var);
        }

        // POST: Category_CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User_Type collection)
        {
            try
            {
                User_TypeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
