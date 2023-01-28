
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Difficulty_Learning.Models
{
   
    public class Category_Course
    {
        [Key]
        [Display(Name = "Code")]
        public int CategoryCourse_ID { get; set; }

        [Display(Name = "Category Type")]
        [StringLength(50)]
        public string CategoryCourse_Name { get; set; } = string.Empty;

    }
}
