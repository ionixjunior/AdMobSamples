using System;
using AdMobCross.Droid.Renderers;
using AdMobCross.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using static Android.App.Application;

[assembly: ExportRenderer(typeof(ContentPage), typeof(LifecycleLitePageRenderer))]
namespace AdMobCross.Droid.Renderers
{
    public class LifecycleLitePageRenderer : PageRenderer
    {
        private IActivityLifecycleCallbacks _activityLifecycleCallbacks;
        private Activity _activity;

        public LifecycleLitePageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement is ILifecycleLite)
            {
                _activity.UnregisterActivityLifecycleCallbacks(_activityLifecycleCallbacks);
            }

            if (e.NewElement is ILifecycleLite lifecycleLite)
            {
                _activity = Context.GetActivity();
                _activityLifecycleCallbacks = new CustomActivityLifecycleCallbacks(lifecycleLite);
                _activity.RegisterActivityLifecycleCallbacks(_activityLifecycleCallbacks);
            }
        }

        private class CustomActivityLifecycleCallbacks : Java.Lang.Object, IActivityLifecycleCallbacks
        {
            private readonly ILifecycleLite _lifecycleLite;

            public CustomActivityLifecycleCallbacks(ILifecycleLite lifecycleLite)
            {
                _lifecycleLite = lifecycleLite;
            }

            public void OnActivityCreated(Android.App.Activity activity, Bundle savedInstanceState)
            {
                _lifecycleLite?.OnCreated();
            }

            public void OnActivityDestroyed(Android.App.Activity activity)
            {
                _lifecycleLite?.OnDestroyed();
            }

            public void OnActivityPaused(Android.App.Activity activity)
            {
                
            }

            public void OnActivityResumed(Android.App.Activity activity)
            {
                
            }

            public void OnActivitySaveInstanceState(Android.App.Activity activity, Bundle outState)
            {
                
            }

            public void OnActivityStarted(Android.App.Activity activity)
            {
                
            }

            public void OnActivityStopped(Android.App.Activity activity)
            {
                
            }
        }
    }
}
