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
    [Register ("LanguageViewCell")]
    partial class LanguageViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ImageContainer { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ImageContainer != null) {
                ImageContainer.Dispose ();
                ImageContainer = null;
            }
        }
    }
}