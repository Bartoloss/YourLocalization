﻿namespace YourLocalization.Application.ViewModels.Type
{
    public class ListTypeForListVm
    {
        public List<TypeForListVm> Types { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}