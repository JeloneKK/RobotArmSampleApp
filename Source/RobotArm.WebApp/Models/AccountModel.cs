using RobotArm.WebApp.Models.Interfaces;
using RobotArm.WebApp.ViewModels;

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