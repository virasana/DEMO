﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILoggingService
    {
        void Log(string text);
        void WriteLine(string text);
    }
}
