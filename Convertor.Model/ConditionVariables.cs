using Convertor.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Convertor.Model
{
    public class ConditionVariables
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public double Time { get; set; }
        public ConditionType ConditionType { get; set; }
    }
}
