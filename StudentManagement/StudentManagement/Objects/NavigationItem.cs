﻿using StudentManagement.Commands;
using StudentManagement.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudentManagement.Objects
{
    public class NavigationItem
    {
        public string NavigationHeader { get; set; }
        public bool CanBeExpanded { get; set; }
        public ObservableCollection<NavigationItem> ExpandedItems { get; set; }
        public object NavigationItemViewModel { get; set; }
        public object RightSideBarNavigationItemViewModel { get; set; }
        public ICommand GoToView { get; set; }
        public static LayoutViewModel LayoutViewModel { get; set; }
        public string Icon { get; set; }

        public NavigationItem(string navigationHeader, bool canBeExpanded, ObservableCollection<NavigationItem> expandedItems, object navigationItemViewModel, object rightSideBarNavigationItemViewModel, LayoutViewModel layoutViewModel, string icon)
        {
            NavigationHeader = navigationHeader;
            CanBeExpanded = canBeExpanded;
            ExpandedItems = expandedItems;
            NavigationItemViewModel = navigationItemViewModel;
            RightSideBarNavigationItemViewModel = rightSideBarNavigationItemViewModel;
            LayoutViewModel = layoutViewModel;
            Icon = icon;
            GoToView = new RelayCommand<object>((_) => true, (_) => GoToViewFunction());
        }

        private void GoToViewFunction()
        {
            LayoutViewModel.ContentViewModel = NavigationItemViewModel;
            LayoutViewModel.RightSideBar = RightSideBarNavigationItemViewModel;
        }
    }
}
