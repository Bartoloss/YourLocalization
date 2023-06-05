namespace YourLocalization.Domain.Model
{
    public class Type : BaseEntity
    {
        //public int Id { get; set; }
        //public string Name { get; set; }

        public virtual ICollection<Point> Points { get; set; }
    }
}