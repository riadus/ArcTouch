using IMDB.Core;
using IMDB.Domain.Interfaces;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using RiadIMDB.iOS.IoC;

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
            Mvx.RegisterType<IDeviceInformations, DeviceInformationsIOS>();
            base.InitializePlatformServices();
        }
    }
}
