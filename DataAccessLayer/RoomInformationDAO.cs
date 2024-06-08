using BussinessObjects;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class RoomInformationDAO : DBUtils
    {

        public List<RoomInformation> GetAllRooms()
        {
            List<RoomInformation> rooms = new List<RoomInformation>();
            string query = "select * from RoomInformation";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rooms.Add(new RoomInformation()
                    {
                        RoomID = reader.GetInt32(0),
                        RoomNumber = reader.GetString(1),
                        RoomDetailDescription = reader.GetString(2),
                        RoomMaxCapacity = reader.GetInt32(3),
                        RoomTypeID = reader.GetInt32(4),
                        RoomStatus = reader.GetByte(5),
                        RoomPricePerDay = reader.GetDecimal(6)
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

            return rooms;
        }

        public List<RoomInformation> GetRoomsByRoomNumber(string number)
        {
            List<RoomInformation> rooms = new List<RoomInformation>();
            string query = "select * from RoomInformation where lower(RoomNumber) like @number";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@number", "%" + number + "%");
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rooms.Add(new RoomInformation()
                    {
                        RoomID = reader.GetInt32(0),
                        RoomNumber = reader.GetString(1),
                        RoomDetailDescription = reader.GetString(2),
                        RoomMaxCapacity = reader.GetInt32(3),
                        RoomTypeID = reader.GetInt32(4),
                        RoomStatus = reader.GetByte(5),
                        RoomPricePerDay = reader.GetDecimal(6)
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

            return rooms;

        }

        public RoomInformation getRoomById(int id)
        {
            string query = "select * from RoomInformation where RoomID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            RoomInformation room = new RoomInformation();
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    room = new RoomInformation()
                    {
                        RoomID = reader.GetInt32(0),
                        RoomNumber = reader.GetString(1),
                        RoomDetailDescription = reader.GetString(2),
                        RoomMaxCapacity = reader.GetInt32(3),
                        RoomTypeID = reader.GetInt32(4),
                        RoomStatus = reader.GetByte(5),
                        RoomPricePerDay = reader.GetDecimal(6)
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

            return room;
        }


        public void AddRoom(RoomInformation room)
        {
            string query = "insert into RoomInformation (RoomNumber, RoomDetailDescription, RoomMaxCapacity, RoomTypeID, RoomStatus, RoomPricePerDay)" +
                " values (@number, @description, @capacity, @typeID, @status, @price)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", room.RoomID);
            cmd.Parameters.AddWithValue("@number", room.RoomNumber);
            cmd.Parameters.AddWithValue("@description", room.RoomDetailDescription);
            cmd.Parameters.AddWithValue("@capacity", room.RoomMaxCapacity);
            cmd.Parameters.AddWithValue("@typeID", room.RoomTypeID);
            cmd.Parameters.AddWithValue("@status", 1);
            cmd.Parameters.AddWithValue("@price", room.RoomPricePerDay);


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


        public void updateRoom(RoomInformation room)
        {
            string query = "update RoomInformation set RoomNumber = @number, RoomDetailDescription = @description" +
                ", RoomMaxCapacity = @capacity, RoomTypeID = @typeID, RoomPricePerDay = @price where RoomID = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", room.RoomID);
            cmd.Parameters.AddWithValue("@number", room.RoomNumber);
            cmd.Parameters.AddWithValue("@description", room.RoomDetailDescription);
            cmd.Parameters.AddWithValue("@capacity", room.RoomMaxCapacity);
            cmd.Parameters.AddWithValue("@typeID", room.RoomTypeID);
            cmd.Parameters.AddWithValue("@price", room.RoomPricePerDay);

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

        public void DeleteRoom(int id)
        {
            string query = "delete RoomInformation where RoomID = @id";
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


    }
}
