using System.Web;

namespace RobotArm.WebApp.Helpers
{
    public class CurrentSessionFacade
    {
        private const string JoinKey = "Join";

        public static string Join
        {
            get => (string)HttpContext.Current.Session[JoinKey];

            set => HttpContext.Current.Session[JoinKey] = value;
        }

        public static void Remove(string sessionVariable)
        {
            HttpContext.Current.Session.Remove(sessionVariable);
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}