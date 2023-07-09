using YourLocalization.Domain.Interface;

namespace YourLocalization.Infrastructure.Repositories
{
    public class TypeRepository : ITypeRepository
    {
        private readonly Context _context;

        public TypeRepository(Context context)
        {
            _context = context;
        }

        public int AddType(Domain.Model.Type type)
        {
            _context.Add(type);
            _context.SaveChanges();
            return type.Id;
        }

        public void DeleteType(int typeId)
        {
            var type = _context.Types.Find(typeId);
            if (type != null)
            {
                _context.Types.Remove(type);
                _context.SaveChanges();
            }
        }

        public IQueryable<Domain.Model.Type> GetAllTypes()
        {
            return _context.Types;
        }

        public Domain.Model.Type? GetTypeById(int typeId)
        {
            return _context.Types.FirstOrDefault(t => t.Id == typeId);
        }

        public void UpdateType(YourLocalization.Domain.Model.Type type)
        {
            _context.Attach(type);
            _context.Entry(type).Property("Name").IsModified = true;
            _context.SaveChanges();
        }
    }
}