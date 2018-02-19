using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest2.objects;
using XamarinTest2.util;

namespace XamarinTest2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageFeedYouTube : ContentPage
	{

         ObservableCollection<VideoInformation> Videos;
         YTSearch vs = new YTSearch();

		public PageFeedYouTube (string querry)
		{
			InitializeComponent ();

            this.Videos = new ObservableCollection<VideoInformation>();

            foreach (VideoInformation vi in vs.SearchQuery(querry, 1))
                this.Videos.Add(vi);
          
           
            VideosView.ItemsSource = this.Videos;
		}

        void OnCellTapped(Object sender, EventArgs args)
        {
            var cell = sender as ViewCell;

            cell.Height = 100000;
            cell.ForceUpdateSize();
        }

       async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            if (e != null)
            {
                await Navigation.PushAsync(new VideoPlayer
                {
                    BindingContext = e.SelectedItem as VideoInformation
                });
            }
        }
	}
}