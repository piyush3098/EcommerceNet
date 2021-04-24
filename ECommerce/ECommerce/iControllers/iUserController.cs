using System;
using System.Collections.Generic;
using ECommerce.Models;

namespace ECommerce.controller
{
    public interface iUserController
    {
        UserModel AddUser(UserModel userModel);

        List<UserModel> GetUsers(int id);

        void UpdateUser(UserModel userModel);

        void DeleteUser(UserModel userModel);

        UserModel GetUser(int id);

        UserModel GetUserBy(Int64 phoneNumber, string email);
       UserModel getLogin(string username, string password);


    }
}