using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace ECommerce.Models
{
    public class UserModel
    {
        [Key]
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public Int64 User_Phone { get; set; }
        public string User_Email { get; set; }
        public string user_password { get; set; }
        

    }
}