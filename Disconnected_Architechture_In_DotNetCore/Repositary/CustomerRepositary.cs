using Disconnected_Architechture_In_DotNetCore.Entities;
using Disconnected_Architechture_In_DotNetCore.InterFace;
using System.Data;
using System.Data.SqlClient;

namespace Disconnected_Architechture_In_DotNetCore.Repositary
{
    public class CustomerRepositary :ICustomerRepositary
    {
        string connectionstrnig = "data source=DESKTOP-NORDVAN\\MSSQLSERVER01;integrated security=yes;initial catalog=NagendraDB";

        public async Task<bool> AddCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionstrnig))//here we are getting the conection string
            {
                SqlCommand cmd = new SqlCommand("Usp_AddBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //cmd.Parameters.AddWithValue("@id", bookingDetail.id);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@City", customer.City);
                //await cmd.ExecuteNonQueryAsync();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");

            }
            return true;
        }

        

        public async Task<bool> DeleteCustomerById(int id)
        {
            using(SqlConnection con=new SqlConnection(connectionstrnig))
            {
                
                SqlCommand cmd = new SqlCommand("Usp_DeleteBooking", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Booking");

            }
            return true;
        }


        public async Task<List<Customer>> GetAllCustomer()
        {
            List<Customer> list12 = new List<Customer>();
            using(SqlConnection con=new SqlConnection(connectionstrnig))
            {
                SqlCommand cmd = new SqlCommand("Usp_GetAllBooking", con);
                cmd.CommandType=CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dd=new DataSet();
                da.Fill(dd,"Customer");
                foreach (DataRow row in dd.Tables["Customer"].Rows)
                {
                    //foreach is looping mechansim which is used to iterate data one by one
                    Customer obj = new Customer();//this is booking object it will store only 1 object/record
                    obj.id = Convert.ToInt32(row["id"]);
                    obj.CustomerName = Convert.ToString(row["CustomerName"]);
                    obj.Email = Convert.ToString(row["Email"]);
                    obj.City = Convert.ToString(row["City"]);
                    obj.Country = Convert.ToString(row["Country"]);
                    list12.Add(obj);//here that booking object we are adding to list objects
                }
               
            }
            return list12;
            
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            Customer booking = new Customer();

            using (SqlConnection con = new SqlConnection(connectionstrnig))
            {
                // string sqlQuery = "SELECT * FROM Countries WHERE Id= " + id;//inline query usage 

                SqlCommand cmd = new SqlCommand("Usp_GetBookingById", con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
                foreach (DataRow row in ds.Tables["Customer"].Rows)
                {
                    //  Booking objBooking = new Booking();
                    booking.id = Convert.ToInt32(row["id"]);
                    booking.CustomerName = Convert.ToString(row["CustomerName"]);
                    booking.Email = Convert.ToString(row["Email"]);
                    booking.City = Convert.ToString(row["City"]);
                    booking.Country = Convert.ToString(row["Country"]);
                }
            }
            return booking;
        }

       

               
        

        public async Task<bool> UpdateCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection(connectionstrnig))
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateBooking", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", customer.id);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@City", customer.City);
                cmd.Parameters.AddWithValue("@Country", customer.Country);
                cmd.Parameters.AddWithValue("@Email", customer.Email);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
            }
            return true;
        }

    }
}
