using System;
using IMDB.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;

namespace RiadIMDB.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(IMvxApplicationDelegate applicationDelegate, UIKit.UIWindow window) : base(applicationDelegate, window)
        {

        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializePlatformServices()
        {
            base.InitializePlatformServices();
        }
    }
}
