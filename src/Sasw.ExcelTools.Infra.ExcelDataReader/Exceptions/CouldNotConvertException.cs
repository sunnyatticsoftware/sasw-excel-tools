﻿namespace Sasw.ExcelTools.Infra.ExcelDataReader.Exceptions
{
    using System;

    public class CouldNotConvertException   
        : Exception
    {
        public CouldNotConvertException(string message)
            : base(message)
        {
        }

        public CouldNotConvertException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}
