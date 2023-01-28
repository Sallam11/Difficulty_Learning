using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Difficulty_Learning.Models
{
    public class User
    {
        [Key]
        public int  Users_ID { get; set; }

        [Display(Name = "Users Type")]
        public int  Users_TypeID { get; set; }
        [StringLength(20)]
        [Display(Name = "UserName")]
        public string Users_UserName { get; set; }

        [StringLength(20)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]

        public string User_Password { get; set; }
        [StringLength(50)]
        [Display(Name = "Mail")]
     
        public string User_Mail { get; set; }
        [StringLength(150)]
        [Display(Name = "Full Name")]
        public string User_FullName { get; set; }
        public DateTime User_CreatedDate { get; set; }
        public bool Users_Active { get; set; }

        [ForeignKey("User_TypeID")]
        [NotMapped]
        public User_Type? Users_Type { get; set; }
        [NotMapped]
        public List<User_Type> Users_Typelist { get; set; } = new List<User_Type>();

    }
}
