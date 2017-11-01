using RobotArm.WebApp.ViewModels;

namespace RobotArm.WebApp.Models.Interfaces
{
    public interface IAccountModel
    {
        LoginViewModel GetLoginViewModel(string returnUrl);
    }
}