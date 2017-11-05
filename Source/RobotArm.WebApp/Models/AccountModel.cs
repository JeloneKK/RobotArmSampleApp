using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;
using RobotArm.WebApp.ViewModels.UserManagement;

namespace RobotArm.WebApp.Models
{
    public class AccountModel : IAccountModel
    {
        public LoginViewModel GetLoginViewModel(string returnUrl)
        {
            throw new System.NotImplementedException();
        }
    }
}