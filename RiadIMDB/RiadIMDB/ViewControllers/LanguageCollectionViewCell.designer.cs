// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace RiadIMDB.iOS.Views
{
    [Register ("LanguageCollectionViewCell")]
    partial class LanguageCollectionViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MvvmCross.Binding.iOS.Views.MvxImageView FlagImage { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FlagImage != null) {
                FlagImage.Dispose ();
                FlagImage = null;
            }
        }
    }
}