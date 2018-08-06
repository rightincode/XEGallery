using System.Windows.Input;
using Xamarin.Forms;

namespace XEGallery.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {

        }

        public ICommand AppInfoCommand => new Command(() => LoadAppInfoView());
               

        private void LoadAppInfoView()
        {

        }


    }
}
