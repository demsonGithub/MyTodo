using MyTodo.Api.Infratructure.ApiResultModel;

namespace MyTodo.Api.Infratructure.ApiResultModel
{
    public class ApiResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ApiResultCode code { get; set; } = ApiResultCode.Success;

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; } = "success";

        /// <summary>
        /// 响应结果
        /// </summary>
        public object data { get; set; } = default(object);

        public static ApiResult Success()
        {
            var entity = new ApiResult()
            {
                code = ApiResultCode.Success,
                msg = "success",
            };

            return entity;
        }

        public static ApiResult Success(object data, string msg = "success")
        {
            var entity = new ApiResult()
            {
                code = ApiResultCode.Success,
                msg = msg,
                data = data
            };

            return entity;
        }

        public static ApiResult Error(string msg, ApiResultCode code = ApiResultCode.Exception)
        {
            return new ApiResult()
            {
                code = code,
                msg = msg,
            };
        }
    }

    public class ApiResult<T> : ApiResult
    {
        public virtual T data { get; set; }

        public static ApiResult<T> Success(T data, string msg = "success")
        {
            var entity = new ApiResult<T>()
            {
                code = ApiResultCode.Success,
                msg = msg,
                data = data
            };

            return entity;
        }
    }
}