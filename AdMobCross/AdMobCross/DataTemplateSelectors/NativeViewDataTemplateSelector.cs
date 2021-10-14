using AdMobCross.Enums;
using AdMobCross.Models;
using AdMobCross.ViewCells;
using Xamarin.Forms;

namespace AdMobCross.DataTemplateSelectors
{
    public class NativeViewDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _itemTemplate;
        private readonly DataTemplate _adTemplate;

        public NativeViewDataTemplateSelector()
        {
            _itemTemplate = new DataTemplate(typeof(ItemCell));
            _adTemplate = new DataTemplate(typeof(AdCell));
        }

        protected override DataTemplate OnSelectTemplate(object obj, BindableObject container)
        {
            if (obj is Item item)
            {
                return item.Type switch
                {
                    ItemType.Ad => _adTemplate,
                    _ => _itemTemplate
                };
            }

            return _itemTemplate;
        }
    }
}
