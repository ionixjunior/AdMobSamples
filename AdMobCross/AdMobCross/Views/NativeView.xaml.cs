using AdMobCross.Interfaces;
using AdMobCross.ViewModels;
using Xamarin.Forms;

namespace AdMobCross.Views
{
    public partial class NativeView : ContentPage, ILifecycleLite
    {
        private readonly INative _native;
        private readonly NativeViewModel _viewModel;

        public NativeView()
        {
            InitializeComponent();
            _native = DependencyService.Resolve<INative>();
            BindingContext = _viewModel = new NativeViewModel(_native);
        }

        public void OnCreated() => _viewModel.OnCreated();

        public void OnDestroyed() => _viewModel.OnDestroyed();
    }
}
