using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationBE.Models
{
    public class DAL
    {

        public Response register(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Users(FirstName,LastName,Password,Email,CreatedOn) values(@FirstName,@LastName,@Password,@Email,@CreatedOn)", connection);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            cmd.Parameters.AddWithValue("@CreatedOn", users.CreatedOn);
            //cmd.Parameters.AddWithValue("@Fund", 0);
            //cmd.Parameters.AddWithValue("@Type", "Users");
            //cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User Registered Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User Registration failed";
            }

            return response;
        }

        public Response AddMessage(AddMessage users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into Comments(Box) values(@Box)", connection);
            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Box", users.Box);
            //cmd.Parameters.AddWithValue("@Fund", 0);
            //cmd.Parameters.AddWithValue("@Type", "Users");
            //cmd.Parameters.AddWithValue("@Type", "Pending");
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Message Added Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Message isn't added";
            }

            return response;
        }
        public Response AddUser(AddUser usi, SqlConnection connection)
        {
            
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("insert into UserInput(UserName,Dtime,OrderName,Comments) values(@UserName,@Dtime,@OrderName,@Comments)", connection);
            cmd.Parameters.AddWithValue("@UserName", usi.UserName);
            cmd.Parameters.AddWithValue("@Dtime", usi.Dtime);
            cmd.Parameters.AddWithValue("@OrderName", usi.OrderName);
            cmd.Parameters.AddWithValue("@Comments", usi.Comments);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order Registered Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order Registration failed";
            }

            return response;
        }


        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Users WHERE Email LIKE @Email AND Password LIKE @Password;", connection);
            //da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", users.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode = 200;
                response.StatusMessage = "User is Valid";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User is InValid";
                response.user = null;
            }
            return response;
        }

        public Response viewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Users", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                user.CreatedOn = Convert.ToString(dt.Rows[0]["CreatedOn"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatusCode = 200;
                response.StatusMessage = "User Exists";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does not exist";
                response.user = user;
            }
            return response;
        }

        public registerdetails getregisters(SqlConnection connection)
        {
            registerdetails rd = new registerdetails();
            string query = "select CreatedOn as registereddate,count(CreatedOn) as noofusers from Users Group by CreatedOn order by Createdon asc";
            SqlDataAdapter adp = new SqlDataAdapter(query, connection);
            adp.SelectCommand.CommandType = CommandType.Text;
            //here temporary storing data iam creating lists of string and int
            List<string> t1 = new List<string>();
            List<int> t2 = new List<int>();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var temp1 = Convert.ToString(dt.Rows[i]["registereddate"]);
                var temp2 = Convert.ToInt32(dt.Rows[i]["noofusers"]);
                t1.Add(temp1);
                t2.Add(temp2);
            }
            rd.loggeddatearray = t1;
            rd.noofpersonsarray = t2;
            return rd;
        }

        public Response updateProfile(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_updateProfile", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", users.FirstName);
            cmd.Parameters.AddWithValue("@LastName", users.LastName);
            cmd.Parameters.AddWithValue("@Password", users.Password);
            cmd.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record Updated Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some Error occured, try again after Sometime";
            }

            return response;
        }

        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_addToCart", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@UserId", cart.UserId);
            cmd.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", cart.Discount);
            cmd.Parameters.AddWithValue("@Quantity", cart.Quantity);
            cmd.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            cmd.Parameters.AddWithValue("@ProductID", cart.ProductID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Item added Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item could not be added";
            }

            return response;
        }

        public Response placeOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_PlaceOrder", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", users.ID);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }

            return response;
        }

        public Response orderList(SqlConnection connection)
        {
            Response response = new Response();
            List<reports> listOrder = new List<reports>();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from reports", connection);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    reports order = new reports();
                    order.Dtime = Convert.ToString(dt.Rows[i]["Dtime"]);
                    order.Number = Convert.ToInt32(dt.Rows[i]["Number"]);
                    listOrder.Add(order);
                }
                if (listOrder.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details fetched";
                    response.listOrders1 = listOrder;
            
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details are not available";
                    response.listOrders1 = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details are not available";
                response.listOrders1 = null;
            }



            return response;
        }

        public Response addUpdateProduct(Products product, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("sp_AddUpdateProducts", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", product.ID);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            cmd.Parameters.AddWithValue("@Discount", product.Discount);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Status", product.Status);
            cmd.Parameters.AddWithValue("@Type", product.Type);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product Inserted Successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product isn't saved, Try again";
            }

            return response;
        }

        public Response UserList(SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            SqlDataAdapter cmd = new SqlDataAdapter("select * from Users", connection);

            DataTable dt = new DataTable();
            cmd.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.CreatedOn = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    listUsers.Add(user);
                }
                if (listUsers.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User details fetched";
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User details are not available";
                    response.listUsers = null;
                }
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User details are not available";
                response.listUsers = null;
            }



            return response;
        }


    }
}
