﻿namespace YourLocalization.Application.ViewModels.User
{
    public class ListUserForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}