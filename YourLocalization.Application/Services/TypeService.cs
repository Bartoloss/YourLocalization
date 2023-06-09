﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Domain.Interface;
using Type = YourLocalization.Domain.Model.Type;

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

        public int AddType(NewTypeVm newTypeVm)
        {
            Type newType = _mapper.Map<Type>(newTypeVm);
            int id = _typeRepo.AddType(newType);
            return id;
        }

        public void DeleteType(int id)
        {
            _typeRepo.DeleteType(id);
        }

        public List<Type> GetAllTypesToDropDownList()
        {
            List<Type> allTypes = _typeRepo.GetAllTypes().OrderBy(t => t.Name).ToList();  
            return allTypes;
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
            Type type = _typeRepo.GetTypeById(id);
            NewTypeVm typeVm = _mapper.Map<NewTypeVm>(type);
            return typeVm;
        }

        public void UpdateType(NewTypeVm updateTypeVm)
        {
            Type type = _mapper.Map<Type>(updateTypeVm);
            _typeRepo.UpdateType(type);
        }
    }
}