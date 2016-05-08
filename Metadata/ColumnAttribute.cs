﻿using System;

namespace Backend.Metadata
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string ColumnName { get; }

        public ColumnAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
