﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Common_Methods
{
    public class Common
    {
        public static List<string> GetErrorLevels()
        {
            List<string> lstErrorLevels = new List<string>();
            lstErrorLevels.Add("DEBUG");
            lstErrorLevels.Add("INFO");
            lstErrorLevels.Add("ERROR");
            lstErrorLevels.Add("WARN");
            return lstErrorLevels;
        
        }

        public static List<int> GetPageNumbers(int totalRecords, int pageSize)
        {
            List<int> lstPageNumbers = new List<int>();
            int totalPages = 0;
            if (totalRecords > 0)
            {
                totalPages = Convert.ToInt32(totalRecords / pageSize);
                for (int i = 1; i <= totalPages; i++)
                {
                    lstPageNumbers.Add(i);
                }
            }

            return lstPageNumbers;

        }
    }
}