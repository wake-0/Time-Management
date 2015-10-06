﻿using TimeManager.ManageProjects;
using TimeManager.ManageTodos;
using Prism.Modularity;
using System.Windows;
using TimeManager.Shell.Views;
using Prism.Unity;
using Microsoft.Practices.Unity;
using TimeManager.Navigation;
using Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Prism.RibbonRegionAdapter;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;

namespace TimeManager
{
    public class Bootstrapper : UnityBootstrapper
    {
        #region methods
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var mappings = base.ConfigureRegionAdapterMappings();

            mappings.RegisterMapping(typeof(Ribbon), ServiceLocator.Current.GetInstance<RibbonRegionAdapter>());
            mappings.RegisterMapping(typeof(ContextMenu), ServiceLocator.Current.GetInstance<MergingItemsControlRegionAdapter>());

            return mappings;
        }

        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(ManageTodosModule));
            catalog.AddModule(typeof(ManageProjectsModule));
            catalog.AddModule(typeof(NavigationModule));
        }
        #endregion
    }
}
