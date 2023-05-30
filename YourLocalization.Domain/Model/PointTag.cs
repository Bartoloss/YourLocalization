namespace YourLocalization.Domain.Model
{
    public class PointTag
    {
        public int PointId { get; set; }
        public Point Point { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}