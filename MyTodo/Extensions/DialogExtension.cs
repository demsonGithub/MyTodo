using MyTodo.Common.Events;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Extensions
{
    public static class DialogExtension
    {
        /// <summary>
        /// 推送等待更新消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="model"></param>
        public static void PublishWaitLoading(this IEventAggregator aggregator, WaitModel model)
        {
            aggregator.GetEvent<WaitLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 订阅等待更新
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        public static void RegisterWaitLoading(this IEventAggregator aggregator, Action<WaitModel> action)
        {
            aggregator.GetEvent<WaitLoadingEvent>().Subscribe(action);
        }
    }
}