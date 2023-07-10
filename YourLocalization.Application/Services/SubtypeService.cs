using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourLocalization.Application.Interfaces;
using YourLocalization.Application.ViewModels.Subtype;
using YourLocalization.Application.ViewModels.Type;
using YourLocalization.Domain.Interface;
using YourLocalization.Domain.Model;

namespace YourLocalization.Application.Services
{
    public class SubtypeService : ISubtypeService
    {
        private readonly ISubtypeRepository _subtypeRepo;
        private readonly IMapper _mapper;

        public SubtypeService(ISubtypeRepository subtypeRepo, IMapper mapper)
        {
            _subtypeRepo = subtypeRepo;
            _mapper = mapper;
        }
        public int AddSubtype(NewSubtypeVm newSubtypeVm)
        {
            Subtype newSubtype = _mapper.Map<Subtype>(newSubtypeVm);
            int id = _subtypeRepo.AddSubtype(newSubtype);
            return id;
        }

        public void DeleteSubtype(int id)
        {
            _subtypeRepo.DeleteSubtype(id);
        }

        public ListSubtypeForListVm GetAllSubtypeForList(int pageSize, int pageNo, string searchString)
        {
            List<SubtypeForListVm> subtypes = _subtypeRepo.GetAllSubtypes().Where(p => p.Name.StartsWith(searchString))
               .ProjectTo<SubtypeForListVm>(_mapper.ConfigurationProvider).ToList();
            foreach (var item in subtypes)
            {
                var subtype = _subtypeRepo.GetTypeForSubtype(item.TypeId);
                item.TypeDetails = _mapper.Map<TypeDetailsVM>(subtype);
            }
            List<SubtypeForListVm> subtypesToShow = subtypes.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            ListSubtypeForListVm subtypesForList = new ListSubtypeForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Subtypes = subtypesToShow,
                Count = subtypes.Count
            };
            return subtypesForList;
        }

        public List<Subtype> GetAllTypesToDropDownList()
        {
            List<Subtype> allSubtypes = _subtypeRepo.GetAllSubtypes().OrderBy(t => t.Name).ToList();
            return allSubtypes;
        }

        public NewSubtypeVm GetSubtypeForEdit(int id)
        {
            Subtype subtype = _subtypeRepo.GetSubtypeById(id);
            NewSubtypeVm subtypeVm = _mapper.Map<NewSubtypeVm>(subtype);
            return subtypeVm;
        }

        public void UpdateSubtype(NewSubtypeVm updateSubtypeVm)
        {
            Subtype subtype = _mapper.Map<Subtype>(updateSubtypeVm);
            _subtypeRepo.UpdateSubtype(subtype);
        }
    }
}
