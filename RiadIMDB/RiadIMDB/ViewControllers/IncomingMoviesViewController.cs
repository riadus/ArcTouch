using System;
using IMDB.Core.ViewModels;
using MvvmCross.iOS.Views;
using UIKit;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class IncomingMoviesViewController : MvxViewController<IncomingMoviesViewModel>
    {
        public IncomingMoviesViewController() : base("IncomingMoviesViewController", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}

