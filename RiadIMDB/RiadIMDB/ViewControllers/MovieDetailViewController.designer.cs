// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace RiadIMDB.iOS.Views
{
    [Register ("MovieDetailViewController")]
    partial class MovieDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView BackdropImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView ContentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GenresLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OverviewLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint OverviewWidthConstraint { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReleaseDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BackdropImage != null) {
                BackdropImage.Dispose ();
                BackdropImage = null;
            }

            if (ContentView != null) {
                ContentView.Dispose ();
                ContentView = null;
            }

            if (GenresLabel != null) {
                GenresLabel.Dispose ();
                GenresLabel = null;
            }

            if (OverviewLabel != null) {
                OverviewLabel.Dispose ();
                OverviewLabel = null;
            }

            if (OverviewWidthConstraint != null) {
                OverviewWidthConstraint.Dispose ();
                OverviewWidthConstraint = null;
            }

            if (ReleaseDateLabel != null) {
                ReleaseDateLabel.Dispose ();
                ReleaseDateLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}