namespace CarRegistration.Models
{
    public interface ICarRepository
    {
        void Create(Car car);
        void Delete(int id);
        Car Get(int id);
        List<Car> GetCars();
        void Update(Car car);
        List<Car> Filter(int from, int to);
    }
}
