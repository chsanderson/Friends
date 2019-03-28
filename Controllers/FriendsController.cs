//Christopher Sanderson
//Friends
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Friends.Models;

namespace Friends.Controllers
{
    public class FriendsController : Controller
    {
        private IFriendsRepository repository;

        //this creates initializes the friends repository interface to be used to access the friends repository class 
        public FriendsController(IFriendsRepository repo)
        {
            repository = repo;
        }

        //this returns the friends repository with all the records in the database
        public ViewResult Index() => View(repository.allFriends);

        //this returns the edit view relevant to the record with the specified ID
        public ViewResult Edit(int ID) => View(repository.allFriends.FirstOrDefault(f => f.ID == ID));
        
        //this attempts to edit the friends record
        [HttpPost]
        public IActionResult Edit(Friend newFriend)
        {
            //this checks if the friends model class is valid due to the data annotations and model binding dependencies in the friends class
            if(ModelState.IsValid)
            {
                //this executes the saveFriend method in the IFriendsRepository interface
                repository.SaveFriend(newFriend);

                //this sets a temporary string message to the tempData variable message
                TempData["message"] = $"{newFriend.FirstName} " + $"{newFriend.LastName} has been saved";

                //this redirects the user to the friends index view
                return RedirectToAction("Index");
            }
            else
            {
                //this returns the edit view with the specified error messages
                return View(newFriend);
            }
        }

        //this creates an empty edit view so that a friends records can be added to the database
        public ViewResult Create() => View("Edit", new Friend());

        [HttpPost]
        public IActionResult Delete(int ID)
        {
            //this executed the deleteFriends method in the IFriendsRepository and assigns it to a new friends object
            Friend removeFriend = repository.deleteFriends(ID);
            //this checks to see if the friends object contains no values or not
            if(removeFriend != null)
            {
                //this creates a temporary message altering the user that the record has been deleted
                TempData["message"] = $"{removeFriend.FirstName}" + " " + $"{removeFriend.LastName} was deleted";
            }
            //this redirects the Index view in the Friends Controller
            return RedirectToAction("Index");
        }
    }
}