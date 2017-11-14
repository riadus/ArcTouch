﻿using System;
using System.Linq;
using System.Reflection;
using IMDB.Domain;
using IMDB.Domain.Attributes;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;

namespace IMDB.Core
{
    public class App : MvxApplication
    {
        public App()
        {
            Mvx.RegisterType<IMvxAppStart, AppStart>();
            RegisterServicesFromAllAssemblies();
            RegisterAllViewModels();
        }

        private void RegisterServicesFromAllAssemblies()
        {
            RegisterServicesForAssembly(typeof(DomainAssemblyReference).GetTypeInfo().Assembly);
            RegisterServicesForAssembly(typeof(App).GetTypeInfo().Assembly);
        }

        private void RegisterAllViewModels()
        {
            CreatableTypes().EndingWith("ViewModel").AsTypes().RegisterAsDynamic();
        }

        private void RegisterServicesForAssembly(Assembly assembly)
        {
            var creatableTypes = CreatableTypes(assembly).ToList();

            creatableTypes.WithAttribute<RegisterInterfaceAsDynamicAttribute>().AsInterfaces().RegisterAsDynamic();
            creatableTypes.WithAttribute<RegisterInterfaceAsLazySingletonAttribute>().AsInterfaces().RegisterAsLazySingleton();
        }
    }
}
