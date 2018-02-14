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
	public partial class RestPosts : ContentPage
	{

        ObservableCollection<Post> Posts;
        RestConsumer service = new RestConsumer();

		public RestPosts ()
		{
			InitializeComponent ();

            Posts = new ObservableCollection<Post>();

        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            PostsView.ItemsSource = await service.Request();
        }
        
	}
}