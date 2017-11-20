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

namespace RiadIMDB.iOS.ViewControllers
{
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ChooseLanguageLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InfoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView LanguagesTableView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NavigateToUpcompingMoviesBtn { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ChooseLanguageLabel != null) {
                ChooseLanguageLabel.Dispose ();
                ChooseLanguageLabel = null;
            }

            if (InfoLabel != null) {
                InfoLabel.Dispose ();
                InfoLabel = null;
            }

            if (LanguagesTableView != null) {
                LanguagesTableView.Dispose ();
                LanguagesTableView = null;
            }

            if (NavigateToUpcompingMoviesBtn != null) {
                NavigateToUpcompingMoviesBtn.Dispose ();
                NavigateToUpcompingMoviesBtn = null;
            }
        }
    }
}