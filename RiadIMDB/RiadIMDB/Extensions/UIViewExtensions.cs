using CoreGraphics;
using UIKit;

namespace RiadIMDB.iOS.Extensions
{
    public static class UIViewExtensions
    {
        public static CGPoint GetCenter(this UIView self, CGRect rect)
        {
            var x = (self.Frame.Width - rect.Width) / 2;
            var y = (self.Frame.Height - rect.Height) / 2;
            return new CGPoint(x, y);
        }

        public static CGPoint GetCenter(this UIView self, CGSize size)
        {
            var x = (self.Frame.Width - size.Width) / 2;
            var y = (self.Frame.Height - size.Height) / 2;
            return new CGPoint(x, y);
        }

        public static CGPoint GetCenter(this UIView self, CGSize size, CGPoint offset)
        {
            var x = (self.Frame.Width - size.Width) / 2;
            var y = (self.Frame.Height - size.Height) / 2;
            return new CGPoint(x + offset.X, y + offset.Y);
        }
    }
}
