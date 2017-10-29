namespace RobotArm.Common.ServiceResponses.ResponseData
{
    public class ErrorDto
    {
        public EErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return $"Error code: {ErrorCode.ToString()} \n" + $"Error message: {ErrorMessage}";
        }
    }
}