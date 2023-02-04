using System.ComponentModel;

namespace MyTodo.Api.Shared.ApiResultModel
{
    public enum ApiResultCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        Success = 1000,

        /// <summary>
        /// Token过期
        /// </summary>
        [Description("Token过期")]
        TokenExpire = 2000,

        /// <summary>
        /// 程序自定义的异常
        /// </summary>
        [Description("程序自定义异常")]
        Exception = 3000,

        /// <summary>
        /// 系统错误
        /// </summary>
        [Description("系统错误")]
        SysError = 4000,
    }
}