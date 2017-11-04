﻿using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IUserModel
    {
        UserViewModel[] Get();
        UserViewModel Get(string userId);
        void Update(UserViewModel user);
        void Create(UserViewModel user);
        void Delete(string userId);
    }
}