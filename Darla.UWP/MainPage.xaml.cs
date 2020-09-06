using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Darla.ESI;
using Darla.ESI.Models;
using Darla.UWP.Helpers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Darla.UWP
{
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal ObservableCollection<CategoryBase> Pages = new ObservableCollection<CategoryBase>();

        private Status _status;

        public MainPage()
        {
            InitializeComponent();

            Pages.Add(new Category
            {
                Name = "market",
                Tooltip = "Market",
                ResourceUri = new System.Uri("ms-appx:///Assets/Icons/UI/WindowIcons/market.png")
            });

            Task.Run(() => RequestStatusAsync()).Wait();
        }

        private async Task RequestStatusAsync()
        {
            IESIClient client = (IESIClient)(Application.Current as App).Container.GetService(typeof(IESIClient));
            try
            {
                _status = await client.Status.GetAsync();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_status)));
            }
            finally
            {
                // Do nothing
            }
        }
    }
}
