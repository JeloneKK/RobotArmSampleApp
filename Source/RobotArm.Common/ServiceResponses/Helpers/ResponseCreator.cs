using RobotArm.Common.ServiceResponses.ResponseData;

namespace RobotArm.Common.ServiceResponses.Helpers
{
    public static class ResponseCreator
    {
        public static ResponseDto CreateSuccessResponseDto()
        {
            return new ResponseDto { Status = EResponseStatus.Success };
        }

        public static ResponseDto CreateErrorResponseDto(EErrorCode errorCode, string errorMessage)
        {
            return new ResponseDto
            {
                Status = EResponseStatus.Error,
                Error = new ErrorDto
                {
                    ErrorCode = errorCode,
                    ErrorMessage = errorMessage
                }
            };
        }

        public static ResponseWithDataDto<TData> CreateSuccessResponseWithDataDto<TData>(TData data)
        {
            return new ResponseWithDataDto<TData>
            {
                Response = CreateSuccessResponseDto(),
                Data = data
            };
        }

        public static ResponseWithDataDto<TData> CreateErrorResponseWithDataDto<TData>(EErrorCode errorCode,
            string errorMessage)
        {
            return new ResponseWithDataDto<TData>
            {
                Response = CreateErrorResponseDto(errorCode, errorMessage),
                Data = default(TData)
            };
        }
    }
}