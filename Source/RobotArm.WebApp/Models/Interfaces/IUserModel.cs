using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IUserModel
    {
        UserViewModel[] Get();
        UserViewModel Get(string userId);
        UserDetailsViewModel GetDetails(string userId);
        void Update(UserDetailsViewModel user);
        void Create(UserViewModel user);
        void Delete(string userId);
        RoleViewModel[] GetAllRoles();
    }
}