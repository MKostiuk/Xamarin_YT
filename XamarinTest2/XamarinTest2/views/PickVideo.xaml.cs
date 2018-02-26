using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest2.objects;

namespace XamarinTest2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickVideo : ContentPage
	{
		public PickVideo ()
		{
			InitializeComponent ();
		}

        void PlayPressed(object sender, EventArgs e)
        {
            var video = new VideoInformation();
            video.Url = "Videos/UWPApiVideo.mp4";
            video.Title = "UWPApiVideo";

            var VideoPage = new VideoPlayer();
            VideoPage.BindingContext = video;
            Navigation.PushAsync(VideoPage);
        }
	}
}