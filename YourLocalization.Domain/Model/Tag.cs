namespace YourLocalization.Domain.Model;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<PointTag> PointTags { get; set; }
}