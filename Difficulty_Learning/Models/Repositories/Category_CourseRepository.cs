using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.Models.Repositories
{
    public class Category_CourseRepository : IDifficultyLearningRepository<Category_Course>
    {
        List<Category_Course> Category_Courses;

        Difficulty_LearningDbContext db;

        public Category_CourseRepository(Difficulty_LearningDbContext _db)
        {
            db = _db;
        }
        public void Add(Category_Course entity)
        {
           
            db.Category_Courses.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _var = Find(id);
            db.Category_Courses.Remove(_var);
            db.SaveChanges();
        }

        public Category_Course Find(int id)
        {
            var _var = db.Category_Courses.SingleOrDefault(b => b.CategoryCourse_ID == id);

            return _var;
        }

        public IList<Category_Course> List()
        {
            return db.Category_Courses.ToList();
        }

        public List<Category_Course> Search(string term)
        {
            return db.Category_Courses.Where(a => a.CategoryCourse_Name.Contains(term)).ToList();
        }

        public void Update(int id, Category_Course entity)
        {
            var _Category_Courses = Find(id);
            _Category_Courses.CategoryCourse_Name = entity.CategoryCourse_Name;
            db.SaveChanges();

        }
    }
}
