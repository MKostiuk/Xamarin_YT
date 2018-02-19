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
	public partial class PostEditSql : ContentPage
	{
		public PostEditSql ()
		{
			InitializeComponent ();
		}

        async void OnSaveClicked(Object sender, EventArgs e)
        {
            var p = (Post)BindingContext;
            await App.Database.SaveItemAsync(p);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(Object sender, EventArgs e)
        {
            var p = (Post)BindingContext;
            await App.Database.DeleteItemAsync(p);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(Object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
	}
}