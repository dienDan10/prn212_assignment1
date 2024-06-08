using BussinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO : DBUtils
    {
        public  List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "select * from Customer";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        CustomerFullName = reader.GetString(1),
                        Telephone = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        CustomerBirthday = reader.GetDateTime(4).ToString(),
                        CustomerStatus = reader.GetByte(5),
                        Password = reader.GetString(6),
                    });
                    
                    
                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                con.Close();
            }
            return customers;
        }

        public  Customer getCustomerById(int id)
        {
            string query = "select * from Customer where CustomerID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            Customer customer = new Customer();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer() {
                        CustomerID = reader.GetInt32(0),
                        CustomerFullName = reader.GetString(1),
                        Telephone = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        CustomerBirthday = reader.GetDateTime(4).ToString(),
                        CustomerStatus = reader.GetByte(5),
                        Password = reader.GetString(6),
                    };
                }


            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                con.Close();
            }

            return customer;
            
        }

        public Customer GetCustomerByEmail(string email)
        {

            string query = "select * from Customer where EmailAddress = @email";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@email", email);
            Customer customer = new Customer();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        CustomerFullName = reader.GetString(1),
                        Telephone = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        CustomerBirthday = reader.GetDateTime(4).ToString(),
                        CustomerStatus = reader.GetByte(5),
                        Password = reader.GetString(6),
                    };
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return customer;
        }

        public  void AddCustomer(Customer customer)
        {
            string query = "insert into Customer (CustomerFullName, Telephone, EmailAddress, CustomerBirthDay, CustomerStatus, Password)" +
                " values (@name, @phone, @email, @birthday, @status, @password)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", customer.CustomerFullName);
            cmd.Parameters.AddWithValue("@phone", customer.Telephone);
            cmd.Parameters.AddWithValue("@email", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@birthday", customer.CustomerBirthday);
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@password", customer.Password);

            try
            {
                con.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        public  void UpdateCustomer(Customer customer)
        {
            string query = "update Customer set CustomerFullName = @name, Telephone = @phone" +
                ", EmailAddress = @email, CustomerBirthDay = @birthday, Password = @password where CustomerID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", customer.CustomerID);
            cmd.Parameters.AddWithValue("@name", customer.CustomerFullName);
            cmd.Parameters.AddWithValue("@phone", customer.Telephone);
            cmd.Parameters.AddWithValue("@email", customer.EmailAddress);
            cmd.Parameters.AddWithValue("@birthday", customer.CustomerBirthday);
            cmd.Parameters.AddWithValue("@password", customer.Password);

            try
            {
                con.Open();
                cmd.ExecuteScalar();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public  void DeleteCustomer(int id) {
            string query = "delete Customer where CustomerID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }

        }

        public List<Customer> GetCustomersByName(string name)
        {
            List<Customer> customers = new List<Customer>();
            string query = "select * from Customer where lower(CustomerFullName) like @name";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@name", "%" + name.ToLower() + "%");
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new Customer()
                    {
                        CustomerID = reader.GetInt32(0),
                        CustomerFullName = reader.GetString(1),
                        Telephone = reader.GetString(2),
                        EmailAddress = reader.GetString(3),
                        CustomerBirthday = reader.GetDateTime(4).ToString(),
                        CustomerStatus = reader.GetByte(5),
                        Password = reader.GetString(6),
                    });


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return customers;

        }

    }
}
