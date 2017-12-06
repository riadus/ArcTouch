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

namespace RiadIMDB.iOS
{
    [Register ("DialogMessageView")]
    partial class DialogMessageView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel InfoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView LoadingIndicator { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MessageLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (InfoLabel != null) {
                InfoLabel.Dispose ();
                InfoLabel = null;
            }

            if (LoadingIndicator != null) {
                LoadingIndicator.Dispose ();
                LoadingIndicator = null;
            }

            if (MessageLabel != null) {
                MessageLabel.Dispose ();
                MessageLabel = null;
            }
        }
    }
}