using System.Collections.Generic;
using System.Linq;

using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.controller
{
    public class UserService : iUserController
    {
        public AppDbContext _Context;
        public UserService(AppDbContext context)
        {
            _Context = context;
        }
        public UserModel AddUser(UserModel userModel)
        {
            _Context.UserMaster.Add(userModel);
            _Context.SaveChanges();
            return userModel;
        }
        public List<UserModel> GetUsers()
        {
            return _Context.UserMaster.ToList();
        }
        public void UpdateUser(UserModel userModel)
        {
            var updateUser = _Context.UserMaster.Find(userModel.User_Id);
            if (updateUser != null)
            {
                updateUser.User_Name = userModel.User_Name;
                updateUser.User_Email = userModel.User_Email;
                updateUser.User_Phone = userModel.User_Phone;
                _Context.UserMaster.Update(updateUser);
                _Context.SaveChanges();
            }
        }
        public UserModel GetUser(int id)
        {
            return _Context.UserMaster.SingleOrDefault(x => x.User_Id == id);
        }
        public UserModel GetUserBy(long phoneNumber, string email)
        {
            return _Context.UserMaster.SingleOrDefault(model =>
                model.User_Email == email || model.User_Phone == phoneNumber);
        }
        public List<UserModel> GetUsers(int id)
        {
            return _Context.UserMaster.ToList();
        }
        public void DeleteUser(UserModel userModel)
        {
            _Context.UserMaster.Remove(userModel);
            _Context.SaveChanges();
        }


        public UserModel getLogin(string username, string password)
        {
            return _Context.UserMaster.SingleOrDefault(x => x.User_Email == username && x.user_password == password);
        }
    }

}