﻿using System;
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
		}

        void SearchVideo(Object sender, EventArgs e)
        {
            var ResultPage = new PageFeedYouTube(Vid.Text);
            Navigation.PushAsync(ResultPage);
        }
	}
}