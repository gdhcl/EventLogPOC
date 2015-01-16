using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomLoggingSearch.Common_Methods
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
            lstErrorLevels.Add("ALL");
            return lstErrorLevels;
        
        }

        public static List<string> GetNoOfRecords()
        {
            List<string> lstNoOfRecords = new List<string>();
            lstNoOfRecords.Add("10");
            lstNoOfRecords.Add("20");
            lstNoOfRecords.Add("50");
            lstNoOfRecords.Add("100");
            return lstNoOfRecords;

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