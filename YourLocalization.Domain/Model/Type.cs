namespace YourLocalization.Domain.Model;

public class Type
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Point> Points { get; set; }
}