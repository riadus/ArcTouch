using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using RiadIMDB.iOS;
using UIKit;

namespace RiadIMDB
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            var setup = new Setup(this, Window);
            setup.Initialize();

            Window.MakeKeyAndVisible();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            return true;
        }
    }
}

