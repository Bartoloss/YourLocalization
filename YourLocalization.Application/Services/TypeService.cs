using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Point;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Domain.Interface;

namespace YourLocalization.Application.Services
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepo;
        private readonly IMapper _mapper;

        public TypeService(ITypeRepository typeRepo, IMapper mapper)
        {
            _typeRepo = typeRepo;
            _mapper = mapper;
        }

        public int AddType(NewTypeVm point)
        {
            YourLocalization.Domain.Model.Type newType = _mapper.Map<YourLocalization.Domain.Model.Type>(point);
            int id = _typeRepo.AddType(newType);
            return id;
        }

        public void DeleteType(int id)
        {
            _typeRepo.DeleteType(id);
        }

        public ListTypeForListVm GetAllTypeForList(int pageSize, int pageNo, string searchString)
        {
            List<TypeForListVm> types = _typeRepo.GetAllTypes().Where(p => p.Name.StartsWith(searchString))
               .ProjectTo<TypeForListVm>(_mapper.ConfigurationProvider).ToList();
            List<TypeForListVm> typesToShow = types.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListTypeForListVm typesForList = new ListTypeForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Types = typesToShow,
                Count = types.Count
            };
            return typesForList;
        }

        public NewTypeVm GetTypeForEdit(int id)
        {
            var type = _typeRepo.GetTypeById(id);
            var typeVm = _mapper.Map<NewTypeVm>(type);
            return typeVm;
        }

        public void UpdateType(NewTypeVm model)
        {
            var type = _mapper.Map<YourLocalization.Domain.Model.Type>(model);
            _typeRepo.UpdateType(type);

        }
    }
}
