﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC5Course.Models
{
    public  class 產品名稱至少包含兩個空白字元Attribute : DataTypeAttribute
    {
        public 產品名稱至少包含兩個空白字元Attribute():base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string str = (string)value;
            return str.Count(p => p == ' ') >= 2;
        }
    }
}