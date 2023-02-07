﻿using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTodo.Common.Events
{
    public class WaitModel
    {
        public bool IsOpen { get; set; }
    }

    public class WaitLoadingEvent : PubSubEvent<WaitModel>
    {
    }
}