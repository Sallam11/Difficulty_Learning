using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.Models.Repositories
{
    public class CourseRepository : IDifficultyLearningRepository<Course>
    {

        Difficulty_LearningDbContext db;

        public CourseRepository(Difficulty_LearningDbContext _db)
        {
            db = _db;
        }
        public void Add(Course entity)
        {
           
            db.Courses.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _var = Find(id);
            db.Courses.Remove(_var);
            db.SaveChanges();
        }

        public Course Find(int id)
        {
            var _var = db.Courses.SingleOrDefault(b => b.Course_ID == id);

            return _var;
        }

        public IList<Course> List()
        {
           
          return db.Courses.ToList();
        }

        public List<Course> Search(string term)
        {
            return db.Courses.Where(a => a.Course_Name.Contains(term)).ToList();
        }

        public void Update(int id, Course entity)
        {
            var _Category_Courses = Find(id);
            _Category_Courses.Course_Name = entity.Course_Name;
            _Category_Courses.Course_UserID = entity.Course_UserID;
            _Category_Courses.Course_CategoryID = entity.Course_CategoryID;
            _Category_Courses.Course_Path = entity.Course_Path;
            db.SaveChanges();

        }
    }
}
