using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Darla.UWP.Helpers
{
    public abstract class CategoryBase
    {
    }

    public class Category : CategoryBase
    {
        public string Name { get; set; }
        public string Tooltip { get; set; }
        public Uri ResourceUri { get; set; }
    }

    public class MenuItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemTemplate { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            return item is Category ? ItemTemplate : null;
        }
    }
}
