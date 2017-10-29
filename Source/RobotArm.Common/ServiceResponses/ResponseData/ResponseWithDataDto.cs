namespace RobotArm.Common.ServiceResponses.ResponseData
{
    public class ResponseWithDataDto<TData>
    {
        public ResponseDto Response { get; set; }
        public TData Data { get; set; }
    }
}