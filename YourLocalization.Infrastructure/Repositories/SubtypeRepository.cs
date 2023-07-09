using YourLocalization.Domain.Interface;

namespace YourLocalization.Infrastructure.Repositories
{
    public class SubtypeRepository : ISubtypeRepository
    {
        private readonly Context _context;

        public SubtypeRepository(Context context)
        {
            _context = context;
        }

        public int AddSubtype(Domain.Model.Subtype subtype)
        {
            _context.Add(subtype);
            _context.SaveChanges();
            return subtype.Id;
        }

        public void DeleteSubtype(int subtypeId)
        {
            var subtype = _context.Subtypes.Find(subtypeId);
            if (subtype != null)
            {
                _context.Subtypes.Remove(subtype);
                _context.SaveChanges();
            }
        }

        public IQueryable<Domain.Model.Subtype> GetAllSubtypes()
        {
            return _context.Subtypes;
        }

        public Domain.Model.Subtype? GetSubtypeById(int subtypeId)
        {
            return _context.Subtypes.FirstOrDefault(t => t.Id == subtypeId);
        }

        public void UpdateSubtype(YourLocalization.Domain.Model.Subtype subtype)
        {
            _context.Attach(subtype);
            _context.Entry(subtype).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}