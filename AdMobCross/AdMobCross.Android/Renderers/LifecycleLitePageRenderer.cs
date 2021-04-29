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
        public LifecycleLitePageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement is ILifecycleLite)
            {
            }

            if (e.NewElement is ILifecycleLite lifecycleLite)
            {
            }
        }
    }
}
