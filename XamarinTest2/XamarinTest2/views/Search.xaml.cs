using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Search : ContentPage
	{


		public Search ()
		{
			InitializeComponent ();
            Vid.Text = "lol";
            RechercheBtn.Command = new Command(() => SearchVideo(Vid.Text));
        }

        void SearchVideo(string videText)
        {
            var ResultPage = new PageFeedYouTube(videText);
            Navigation.PushAsync(ResultPage);
        }
	}
}