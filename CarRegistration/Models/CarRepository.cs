using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace CarRegistration.Models
{
    public class CarRepository : ICarRepository
    {
        string connectionString;
        public CarRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Car> GetCars()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("SELECT * FROM Cars").ToList();
            }
        }

        public Car Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>("SELECT * FROM Cars WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Car> Filter (int from, int to)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Car>($@"SELECT * FROM Cars ORDER BY Id OFFSET {from - 1} ROWS FETCH NEXT {to - from + 1} ROWS ONLY").ToList();
            }
        }

        public void Create(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $@"INSERT INTO Cars (Model, RegistrationNumber, UserId) VALUES(@Model, @RegistrationNumber, @UserId)";
                db.Execute(sqlQuery, car);
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Cars SET Model = @Model, RegistrationNumber = @RegistrationNumber, UserId = @UserId WHERE Id = @Id";
                db.Execute(sqlQuery, car);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Cars WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
