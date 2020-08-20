using GUIConvertor.Model.enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUIConvertor.Model
{
    public class ConditionVariables
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public double Time { get; set; }
        public ConditionType ConditionType { get; set; }
    }
}
