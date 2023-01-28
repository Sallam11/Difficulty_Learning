using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.Models.Repositories
{
    public class User_TypeRepository : IDifficultyLearningRepository<User_Type>
    {
        

        Difficulty_LearningDbContext db;

        public User_TypeRepository(Difficulty_LearningDbContext _db)
        {
            db = _db;
        }
        public void Add(User_Type entity)
        {
           
            db.User_Types.Add(entity);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var _var = Find(id);
            db.User_Types.Remove(_var);
            db.SaveChanges();
        }

        public User_Type Find(int id)
        {
            var _var = db.User_Types.SingleOrDefault(b => b.UserType_ID == id);

            return _var;
        }

        public IList<User_Type> List()
        {
            return db.User_Types.ToList();
        }

        public List<User_Type> Search(string term)
        {
            return db.User_Types.Where(a => a.UserType_Name.Contains(term)).ToList();
        }

        public void Update(int id, User_Type entity)
        {
            var _var = Find(id);
            _var.UserType_Name = entity.UserType_Name;
            db.SaveChanges();

        }
    }
}
