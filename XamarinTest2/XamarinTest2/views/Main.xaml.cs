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
	public partial class Main : ContentPage
	{
		public Main ()
		{
			InitializeComponent ();
		}

        public void RatePressed(Object sender)
        {
            Application.Current.MainPage = new Todo.RateAppPage();
        }

        public void SearchPressed(Object sender)
        {
            Application.Current.MainPage = new Search();
        }

        public void PostsPressed(Object sender)
        {
            Application.Current.MainPage = new RestPosts();
        }
	}
}