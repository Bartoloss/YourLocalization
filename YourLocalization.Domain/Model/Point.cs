﻿namespace YourLocalization.Domain.Model
{
    public class Point : BaseEntity
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        public int TypeId { get; set; }

        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Type Type { get; set; }
        public ICollection<PointTag> PointTags { get; set; }
    }
}