using System;
using log4net;
using RobotArm.Common.Logging;
using RobotArm.Common.Patterns.DbContext;
using RobotArm.Common.ServiceResponses.Helpers;
using RobotArm.Common.ServiceResponses.ResponseData;

namespace RobotArm.CommonServices
{
    public abstract class ServiceBase
    {
        protected ILog Log;

        protected ServiceBase(ELogger logger = ELogger.Common)
        {
            Log = LoggerFactory.GetLogger(logger);
        }

        protected virtual ResponseDto PrepareCommonResponse(Action action)
        {
            try
            {
                action.Invoke();
                return ResponseCreator.CreateSuccessResponseDto();
            }
            catch (Exception e)
            {
                this.Log.Error(e);
                return ResponseCreator.CreateErrorResponseDto(EErrorCode.Unknow, e.Message);
            }
        }

        //protected virtual ResponseDto PrepareCommonResponse<T1>(Action<T1> action, T1 param1)
        //{
        //    try
        //    {
        //        action.Invoke(param1);
        //        return ResponseCreator.CreateSuccessResponseDto();
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log.Error(e);
        //        return ResponseCreator.CreateErrorResponseDto(EErrorCode.Unknow, e.Message);
        //    }
        //}

        //protected virtual ResponseDto PrepareCommonResponse<T1, T2>(Action<T1, T2> action, T1 param1, T2 param2)
        //{
        //    try
        //    {
        //        action.Invoke(param1, param2);
        //        return ResponseCreator.CreateSuccessResponseDto();
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log.Error(e);
        //        return ResponseCreator.CreateErrorResponseDto(EErrorCode.Unknow, e.Message);
        //    }
        //}

        protected virtual ResponseWithDataDto<TResult> PrepareCommonResponseWithData<TResult>(Func<TResult> func)
        {
            try
            {
                TResult result = func.Invoke();
                return ResponseCreator.CreateSuccessResponseWithDataDto(result);
            }
            catch (Exception e)
            {
                this.Log.Error(e);
                return ResponseCreator.CreateErrorResponseWithDataDto<TResult>(EErrorCode.Unknow, e.Message);
            }
        }

        //protected virtual ResponseWithDataDto<TResult> PrepareCommonResponseWithData<TResult, T1>(Func<T1, TResult> func, T1 param1)
        //{
        //    try
        //    {
        //        TResult result = func.Invoke(param1);
        //        return ResponseCreator.CreateSuccessResponseWithDataDto(result);
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log.Error(e);
        //        return ResponseCreator.CreateErrorResponseWithDataDto<TResult>(EErrorCode.Unknow, e.Message);
        //    }
        //}

        //protected virtual ResponseWithDataDto<TResult> PrepareCommonResponseWithData<TResult, T1, T2>(Func<T1, T2, TResult> func, T1 param1, T2 param2)
        //{
        //    try
        //    {
        //        TResult result = func.Invoke(param1, param2);
        //        return ResponseCreator.CreateSuccessResponseWithDataDto(result);
        //    }
        //    catch (Exception e)
        //    {
        //        this.Log.Error(e);
        //        return ResponseCreator.CreateErrorResponseWithDataDto<TResult>(EErrorCode.Unknow, e.Message);
        //    }
        //}
    }
}