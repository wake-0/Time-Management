﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Windows.Input;
using TimeManager.Infrastructure;
using PostSharp.Patterns.Model;

namespace TimeManager.Navigation.ViewModels
{
    [NotifyPropertyChanged]
    public class NavigationViewModel
    {
        #region fields
        private readonly IRegionManager regionManager;
        #endregion

        #region properties
        public ICommand NavigationCommand { get; private set; }
        #endregion

        #region ctor
        public NavigationViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigationCommand = new DelegateCommand<string>(NavigateTo);
        }
        #endregion

        #region methods
        private void NavigateTo(string view)
        {
            regionManager.RequestNavigate(RegionNames.MainRegion, new Uri(view, UriKind.Relative));
        }
        #endregion
    }
}
