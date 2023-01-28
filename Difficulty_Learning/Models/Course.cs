using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Difficulty_Learning.Models
{
    public class Course
    {
        [Key]
        [Display(Name = " ID")]
        public int Course_ID { get; set; }

        [Display(Name = " User")]
        public int Course_UserID { get; set; }
        [Display(Name = " Course Category")]
        public int Course_CategoryID { get; set; }

        [Display(Name = "Course Name")]
        [StringLength(50)]
        public string Course_Name { get; set; }

        [Display(Name = " Upload")]
        public string Course_Path { get; set; }





        [ForeignKey("Course_UserID")]
        public User? User { get; set; }

        [ForeignKey("Course_CategoryID")]
        [NotMapped]
        public Category_Course? Category_Course { get; set; }
        [NotMapped]

        public List<Category_Course> Category_Courselist { get; set; } = new List<Category_Course>();
        public List<User> Userslist { get; set; } = new List<User>();

    }
}
