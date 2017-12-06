// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RiadIMDB.iOS.ViewControllers
{
    [Register ("MovieViewCell")]
    partial class MovieViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel GenresLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView OriginalLanguageImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel OverviewLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView PosterImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ReleaseDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView UserLanguageImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (GenresLabel != null) {
                GenresLabel.Dispose ();
                GenresLabel = null;
            }

            if (OriginalLanguageImage != null) {
                OriginalLanguageImage.Dispose ();
                OriginalLanguageImage = null;
            }

            if (OverviewLabel != null) {
                OverviewLabel.Dispose ();
                OverviewLabel = null;
            }

            if (PosterImage != null) {
                PosterImage.Dispose ();
                PosterImage = null;
            }

            if (ReleaseDateLabel != null) {
                ReleaseDateLabel.Dispose ();
                ReleaseDateLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }

            if (UserLanguageImage != null) {
                UserLanguageImage.Dispose ();
                UserLanguageImage = null;
            }
        }
    }
}