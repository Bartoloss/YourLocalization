﻿using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;
using Type = YourLocalization.Domain.Model.Type;

namespace YourLocalization.Infrastructure.Repositoriees
{
    public class PointRepository : IPointRepository
    {
        private readonly Context _context;

        public PointRepository(Context context)
        {
            _context = context;
        }

        public void DeletePoint(int pointId)
        {
            Point? point = _context.Points.Find(pointId);
            if (point != null)
            {
                _context.Points.Remove(point);
                _context.SaveChanges();
            }
        }

        public int AddPoint(Point point)
        {
            _context.Add(point);
            _context.SaveChanges();
            return point.Id;
        }

        public IQueryable<Point> GetsPointsByTypeId(int typeId)
        {
            IQueryable<Point> points = _context.Points.Where(i => i.TypeId == typeId);
            return points;
        }

        public IQueryable<Point> GetAllPoints()
        {
            return _context.Points;
        }

        public IQueryable<Point> GetUserPoints(string name)
        {
            return _context.Points.Where(i => i.CreatedBy == name);
        }

        public Point? GetPointById(int pointId)
        {
            return _context.Points.FirstOrDefault(i => i.Id == pointId);
        }

        public IQueryable<Tag> GetAllTags()
        {
            return _context.Tags;
        }

        public IQueryable<Type> GetAllTypes()
        {
            return _context.Types;
        }

        public void UpdatePoint(Point point)
        {
            _context.Attach(point);
            _context.Entry(point).Property("Name").IsModified = true;
            _context.Entry(point).Property("TypeId").IsModified = true;
            _context.Entry(point).Property("Street").IsModified = true;
            _context.Entry(point).Property("BuildingNumber").IsModified = true;
            _context.Entry(point).Property("ZipCode").IsModified = true;
            _context.Entry(point).Property("City").IsModified = true;
            _context.Entry(point).Property("Country").IsModified = true;
            _context.SaveChanges();
        }

        public Type? GetTypeForPoint(int pointTypeId)
        {
            return _context.Types.FirstOrDefault(i => i.Id == pointTypeId);
        }
    }
}