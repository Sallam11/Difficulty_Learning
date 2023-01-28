using Difficulty_Learning.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Difficulty_Learning.ViewModel
{
    public class CategoryViewModel
    {
        public int Course_ID { get; set; }
        public int Course_UserID { get; set; }
        public int Course_CategoryID { get; set; }
        public string Course_Name { get; set; }
        public string Course_Path { get; set; }
        public int CategoryCourse_ID { get; set; }

        public List <Category_Course> Categorys { get; set; }

        public IFormFile File1{ get; set; }

    }
}
