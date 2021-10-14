using System;
using Xamarin.Forms;

namespace AdMobCross.DataTemplate
{
    public class NativeViewDataTemplateSelector : DataTemplateSelector
    {
        public NativeViewDataTemplateSelector()
        {
        }

        protected override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            throw new NotImplementedException();
        }
    }
}
