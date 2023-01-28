using System.ComponentModel.DataAnnotations;

namespace Difficulty_Learning.Models
{
    public class User_Type
    {
        [Key]
        [Display(Name = "Code")]
        public int UserType_ID { get; set; }

        [Display(Name = "Type User")]
        public string UserType_Name { get; set; } = string.Empty;

    }
}
