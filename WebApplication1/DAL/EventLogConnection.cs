using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplication1.Entity;
using System.Configuration;

namespace WebApplication1
{
    public class EventLogConnection
    {

        string connetionString = ConfigurationManager.ConnectionStrings["CustomConnectionString"].ToString();

        public EventLogWrapper GetEvents(EventLogWrapper obj)
        {
            try
            {
                SqlConnection con = new SqlConnection(connetionString);
                SqlCommand cmd = new SqlCommand("GetEventLog", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FromDate", obj.FromDate);
                cmd.Parameters.Add("@ToDate", obj.ToDate);
                cmd.Parameters.Add("@Level", obj.Level);
                cmd.Parameters.Add("@Message", obj.Message);
                cmd.Parameters.Add("@PageSize", obj.PageSize);
                cmd.Parameters.Add("@PageIndex", obj.PageIndex);

                con.Open();
                SqlDataReader conReader = cmd.ExecuteReader();
                obj.lstEventLog = new List<EventLog>();
                if (conReader.HasRows)
                {
                    EventLog data = null;

                    while (conReader.Read())
                    {
                        data = new EventLog();

                        data.Date = (string)conReader["Date"];
                        data.Level = (string)conReader["Level"];
                        data.Thread = (string)conReader["Thread"];
                        data.Logger = (string)conReader["Logger"];
                        data.Message = (string)conReader["Message"];
                        data.Exceptions = (string)conReader["Exception"];
                        data.RowNumber = (string)conReader["Id"];
                        obj.PageIndex = Convert.ToInt32(conReader["PageIndex"]);
                        obj.PageSize = Convert.ToInt32(conReader["PageSize"]);
                        obj.TotalRecords = Convert.ToInt32(conReader["TotalRecords"]);

                        obj.lstEventLog.Add(data);

                    }
                }
                con.Close();
                con.Dispose();
                return obj;

            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
    }
}