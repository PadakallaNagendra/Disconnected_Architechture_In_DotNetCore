using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.InterFace;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Disconnected_Architechture_In_DotNetCore.Repositary
{
    public class DashRepositary : IDashboardRepositary
    {
        string connectionstrnig = "data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=yes;initial catalog=NagendraDB";
        public async Task<bool> AddDashboardDetails(Dashboard dashboard)
        {
           using(SqlConnection con=new SqlConnection(connectionstrnig))
            {
                SqlCommand cmd=new SqlCommand("sp_Adddashboard", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", dashboard.position);
                cmd.Parameters.AddWithValue("@name", dashboard.name);
                cmd.Parameters.AddWithValue("@weight", dashboard.weight);
                cmd.Parameters.AddWithValue("@symbol", dashboard.symbol);
                cmd.Parameters.AddWithValue("@location", dashboard.location);
                SqlDataAdapter da=new SqlDataAdapter(cmd);
                DataSet ds= new DataSet();
                da.Fill(ds, "Dashboard");
            }
            return true;
        }

        public async Task<List<Dashboard>> GetAllDashboard()
        {
            List<Dashboard> dashboards = new List<Dashboard>();
            using(SqlConnection con=new SqlConnection(connectionstrnig))
            {
                SqlCommand cmd = new SqlCommand("sp_getdashboard", con);
                cmd.CommandType=System.Data.CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                da.Fill(ds, "Dashboard");
                foreach(DataRow row in ds.Tables["Dashboard"].Rows)
                {
                    Dashboard obj=new Dashboard();
                    obj.position = Convert.ToInt32(row["position"]);
                    obj.name = Convert.ToString(row["name"]);
                    obj.weight = Convert.ToInt32(row["weight"]);
                    obj.symbol = Convert.ToString(row["symbol"]);
                    obj.location = Convert.ToString(row["location"]);
                    dashboards.Add(obj);
                }
            }
            return dashboards;
        }

        public async Task<Dashboard> GetDashboardbyId(int id)
        {
            Dashboard  dashboard = new Dashboard();

            using (SqlConnection con = new SqlConnection(connectionstrnig))
            {
                // string sqlQuery = "SELECT * FROM Countries WHERE Id= " + id;//inline query usage 

                SqlCommand cmd = new SqlCommand("sp_getdashboardbyid", con);
                cmd.Parameters.AddWithValue("@position", id);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dashboard");
                foreach (DataRow row in ds.Tables["Dashboard"].Rows)
                {
                    //  Booking objBooking = new Booking();
                    dashboard.position = Convert.ToInt32(row["position"]);
                    dashboard.name = Convert.ToString(row["name"]);
                    dashboard.weight = Convert.ToInt32(row["weight"]);
                    dashboard.symbol = Convert.ToString(row["symbol"]);
                    dashboard.location = Convert.ToString(row["location"]);
                }
            }
            return dashboard;

        }

        public async Task<bool> RemoveDashboardDetailsById(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionstrnig))
            {

                SqlCommand cmd = new SqlCommand("sp_deletedashboardbyid", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dashboard");

            }
            return true;
        }

        public async Task<bool> UpdateDashBoardDetails(Dashboard dashboard)
        {
            using (SqlConnection con = new SqlConnection(connectionstrnig))
            {
                SqlCommand cmd = new SqlCommand("sp_updatedashboard", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", dashboard.position);
                cmd.Parameters.AddWithValue("@name", dashboard.name);
                cmd.Parameters.AddWithValue("@weight", dashboard.weight);
                cmd.Parameters.AddWithValue("@symbol", dashboard.symbol);
                cmd.Parameters.AddWithValue("@location", dashboard.location);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Dashboard");
            }
            return true;
        }
    }
}
