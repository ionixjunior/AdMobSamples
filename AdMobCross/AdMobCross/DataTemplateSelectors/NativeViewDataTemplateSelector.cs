using AdMobCross.ViewCells;
using Xamarin.Forms;

namespace AdMobCross.DataTemplateSelectors
{
    public class NativeViewDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _itemTemplate;

        public NativeViewDataTemplateSelector()
        {
            _itemTemplate = new DataTemplate(typeof(ItemCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return _itemTemplate;
        }
    }
}
