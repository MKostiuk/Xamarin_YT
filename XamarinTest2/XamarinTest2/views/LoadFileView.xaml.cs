using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest2.util;

namespace XamarinTest2.views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadFileView : ContentPage
	{

        const string filename = "temp.txt";

        public LoadFileView ()
		{
			InitializeComponent ();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var fileService = DependencyService.Get<ISaveAndLoad>();
            if (fileService.FileExists(filename))
                labelText.Text = await fileService.LoadTextAsync(filename);
            else
                labelText.Text = "Le fichier n'existe pas!";
        }
    }
}