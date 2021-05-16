using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace Lab3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabBarPage : Xamarin.Forms.TabbedPage
    {
        public TabBarPage()
        {
            Resources = DependencyService.Resolve<ResourceDictionary>();
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);

            if (AppData.LanguageChanged)
            {
                var pages = Children.GetEnumerator();
                pages.MoveNext();
                pages.MoveNext();
                pages.MoveNext();
                CurrentPage = pages.Current;
                AppData.LanguageChanged = false;
            }
        }
    }
}