using System;
using AdMobCross.Interfaces;
using AdMobCross.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentPage), typeof(LifecycleLitePageRenderer))]
namespace AdMobCross.iOS.Renderers
{
    public class LifecycleLitePageRenderer : PageRenderer
    {
        private ILifecycleLite _lifecycleLite;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.NewElement is ILifecycleLite lifecycleLite)
                _lifecycleLite = lifecycleLite;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _lifecycleLite?.OnCreated();
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
            _lifecycleLite?.OnDestroyed();
        }
    }
}
