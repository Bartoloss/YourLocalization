namespace YourLocalization.Domain.Model
{
    public class Tag : BaseEntity
    {
        public ICollection<PointTag> PointTags { get; set; }
    }
}