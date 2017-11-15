using Foundation;
using ObjCRuntime;
using UIKit;

namespace RiadIMDB.iOS.Views
{
    public class ViewFactory
    {
        public static TView Create<TView>(string name) where TView : UIView
        {
            var arr = NSBundle.MainBundle.LoadNib(name, null, null);
            return Runtime.GetNSObject<TView>(arr.ValueAt(0));
        }
    }
}
