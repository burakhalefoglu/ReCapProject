﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingCuncerns.Loging
{
    public class LogDetail
    {
        public string MethodName { get; set; }
        public List<LogParameter> LogParameters { get; set; }
    }
}
