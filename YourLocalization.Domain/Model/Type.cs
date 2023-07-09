namespace YourLocalization.Domain.Model
{
    public class Type : BaseEntity
    {
        public virtual ICollection<Point> Points { get; set; }
        public virtual ICollection<Subtype> Subtypes { get; set; }

    }
}