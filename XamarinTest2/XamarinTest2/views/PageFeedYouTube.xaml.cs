using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest2.objects;

namespace XamarinTest2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PageFeedYouTube : ContentPage
	{

         ObservableCollection<Video> Videos;

		public PageFeedYouTube ()
		{
			InitializeComponent ();

            this.Videos = new ObservableCollection<Video>();

            for (int i = 0; i < 7; i++)
                this.Videos.Add(new Video { Title = "LOL", PictureUrl= "http://testcreative.co.uk/wp-content/uploads/2017/10/Test-Logo-Small-Black-transparent-1.png" });

            VideosView.ItemsSource = this.Videos;
		}
	}
}