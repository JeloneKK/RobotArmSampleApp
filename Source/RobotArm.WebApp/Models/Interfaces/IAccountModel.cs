using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IAccountModel
    {
        LoginViewModel GetLoginViewModel(string returnUrl);
    }
}