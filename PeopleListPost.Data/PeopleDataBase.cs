using System.Collections.Generic;
using System.Data.SqlClient;

namespace PeopleListPost.Data
{
    public class PeopleDataBase
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=People; Integrated Security=true;";

        private void Add(Person p)
        {
            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO People(FirstName, LastName, Age) " +
                                  "VALUES(@firstName, @lastName, @age)";
            command.Parameters.AddWithValue("@firstName", p.FirstName);
            command.Parameters.AddWithValue("@lastName", p.LastName);
            command.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            command.ExecuteNonQuery();
            return;
        }


        public void AddManyPeople(List<Person> people)
        {
            foreach (Person p in people)
            {
                Add(p);
            }
        }

        public List<Person> GetPeople()
        {
            List<Person> people = new();

            using SqlConnection connection = new(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM People";
            connection.Open();

            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                people.Add(new()
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }
            return people;
        }


    }
}