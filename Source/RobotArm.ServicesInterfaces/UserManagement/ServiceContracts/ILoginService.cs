using System.ServiceModel;

namespace RobotArm.ServicesContracts.UserManagement.ServiceContracts
{
    [ServiceContract]
    public interface ILoginService
    {
        [OperationContract]
        void Login(string login, string password);
    }
}