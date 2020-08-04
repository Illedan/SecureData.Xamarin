using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace SecureXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            On<iOS>().SetModalPresentationStyle(UIModalPresentationStyle.FullScreen);
            InitializeComponent();

            for(var i = 0; i < 100; i++)
            {
                Items.Add(new ItemViewModel { Text = "Item  " + i });
            }
            BindingContext = this;
        }

        public List<ItemViewModel> Items { get; } = new List<ItemViewModel>();
    }

    public class ItemViewModel : INotifyPropertyChanged
    {
        public string Text { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
