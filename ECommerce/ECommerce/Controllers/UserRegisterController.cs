using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRegisterController : ControllerBase
    {
        private readonly iUserController _userController;
        public AppDbContext _Context;
        public UserRegisterController(iUserController userController)
        {
            _userController = userController;
        }

        [HttpPost]
        // [Route("[action]")]
        [Route("api/user/AddUser")]
        public IActionResult AddUser(UserModel userModel)
        {
            var data = _userController.GetUserBy(userModel.User_Phone, userModel.User_Email);
            if (data != null)
            {
                return NotFound(new JsonResult("Unsuccessful") { ContentType = "User already exists", StatusCode = 402 });
            }
            _userController.AddUser(userModel);
            return Ok();
        }
        
        [HttpGet]
        // [Route("[action]")]
        [Route("api/user/getUsers/{id}")]
        public IActionResult GetUser(int id)
        {
            var conn = _userController.GetUser(id);
            if(conn != null)
            {
                return Ok(conn);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPut]
        // [Route("[action]")]
        [Route("api/user/getLogin/{userName}/{userPass}")]
        public IActionResult GetLogin(string userName,string userPass)
        {
          //  UserModel userModel = new UserModel();
            var con = _userController.getLogin(userName, userPass);
        
            if (con!=null)
            {
               return Ok(new JsonResult("Successful") { ContentType = "Login Done Successfully", StatusCode = 400 });
            }
            return NotFound(new JsonResult("Unsuccessful") { ContentType = "Fail to Login", StatusCode = 403 });

        }

        [HttpDelete]
        [Route("api/user/removeUsers/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userController.GetUser(id);
            if(user != null)
            {
                _userController.DeleteUser(user);
                return Ok(new JsonResult("Successful") { ContentType = "User Remove Successfully", StatusCode = 400 });
            }
            return NotFound(new JsonResult("Unsuccessful") { ContentType = "Fail to Remove User", StatusCode = 403 });
        }
        [HttpPatch]
        [Route("api/user/updateUsers/{id}")]
        public IActionResult UpdateUser(int id,UserModel userModel)
        {
            var user = _userController.GetUser(id);
            if (user != null)
            {
                userModel.User_Id = user.User_Id;
                _userController.UpdateUser(userModel);
                return Ok(new JsonResult("Successful") { ContentType = "User Detail Updated Successfully", StatusCode = 400 });
            }
            return NotFound(new JsonResult("Unsuccessful") { ContentType = "Fail to Update User Detail", StatusCode = 403 });

        }
    }
}