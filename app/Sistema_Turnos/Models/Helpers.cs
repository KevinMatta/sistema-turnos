﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Turnos.Models
{
    public class Helpers
    {
        public static string GetMessage(Exception Ex)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(Ex.Message);
            while (Ex.InnerException != null)
            {
                stringBuilder.Append(Ex.InnerException);
                Ex = Ex.InnerException;
            }

            return stringBuilder.ToString();
        }
    }
}
