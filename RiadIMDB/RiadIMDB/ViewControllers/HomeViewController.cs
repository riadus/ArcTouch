using System;
using IMDB.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

namespace RiadIMDB.iOS.ViewControllers
{
    public partial class HomeViewController : MvxViewController<HomeViewModel>
    {
        public HomeViewController() : base("HomeViewController", null)
        {
            this.DelayBind(SetBindings);
        }

        private void SetBindings()
        {
            var bindingSet = this.CreateBindingSet<HomeViewController, HomeViewModel>();
            bindingSet.Bind(LoadBtn)
                      .To(vm => vm.LoadCommand);

            bindingSet.Apply();
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

