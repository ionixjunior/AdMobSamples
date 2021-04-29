using AdMobCross.Droid.Renderers;
using AdMobCross.Interfaces;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(LifecycleLitePageRenderer))]
namespace AdMobCross.Droid.Renderers
{
    public class LifecycleLitePageRenderer : PageRenderer
    {
        private ILifecycleLite _lifecycleLite;

        public LifecycleLitePageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement is ILifecycleLite oldLifecycleLite)
            {
                oldLifecycleLite.OnDestroyed();
            }

            if (e.NewElement is ILifecycleLite newLifecycleLite)
            {
                _lifecycleLite = newLifecycleLite;
                newLifecycleLite.OnCreated();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _lifecycleLite?.OnDestroyed();
        }
    }
}
