using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modules.StarterKIT.CustomLogger
{
    public class LogData
    {
        public Color Color { get; private set; }
        public Type Sender { get; private set; }
        public string Log { get; private set; }

    }
}
