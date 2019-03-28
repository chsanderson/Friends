//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Friends.Models
{
    public class Friend
    {
        //initializing primary key and create a getter and setter for the integer ID
        [BindNever]
        [Key]
        public int ID { get; set; }

        //Create a  getter and setter for a string variable called first name
        [Required(ErrorMessage = "Please Enter Your First Name")]//this requires firstname to be set, this is used for model binding to make sure a value is gave in the view
        public string FirstName { get; set; }

        //Create a  getter and setter for a string variable called last name
        [Required(ErrorMessage = "Please Enter Your Last Name")]//this requires lastname to be set, this is used for model binding to make sure a value is gave in the view
        public string LastName { get; set; }
    }
}
