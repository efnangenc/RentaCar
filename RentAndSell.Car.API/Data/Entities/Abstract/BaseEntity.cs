namespace RentAndSell.Car.API.Data.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime? Update { get; set; }
        public DateTime? Delete { get; set; }
        public bool IsDeleted { get; set; } = true;
    }
}
