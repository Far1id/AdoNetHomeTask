using BP202Stadiums.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace BP202Stadiums.Data
{
    class StadiumData
    {
        public void Insert(Stadiums stadium)
        {
            using(SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"INSERT INTO Stadiums (Name,HourPrice,Capacity) Values ('{stadium.Name}',{stadium.HourPrice},{stadium.Capacity})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Stadiums> Select()
        {
            List<Stadiums> stadiums = new List<Stadiums>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadiums";
                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadiums stadium = new Stadiums
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)
                        };

                        stadiums.Add(stadium);
                    }
                }
            }
            return stadiums;
        }
        public void Delete(int Id)
        {
            using (SqlConnection sqlCon = new SqlConnection(Sql.ConnectionString))
            {
                string query = $"DELETE FROM Stadions WHERE Id = @id";
                sqlCon.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlCon);
                sqlCommand.Parameters.AddWithValue("@id", Id);
                sqlCommand.ExecuteNonQuery();
            }
        }

        public Stadiums GetById(int id)
        {
            Stadiums stadium = null;
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadiums WHERE  Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        stadium = new Stadiums
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourPrice = dr.GetInt32(2),
                            Capacity = dr.GetInt32(3)
                        };
                    }
                }
            }
            return stadium;
        }
    }
}
