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
	public partial class SaveFileView : ContentPage
	{

        const string filename = "temp.txt";

		public SaveFileView ()
		{
			InitializeComponent ();
		}

        protected async void OnAppliquerPressed(Object sender)
        {
            var fileService = DependencyService.Get<ISaveAndLoad>();
            await fileService.SaveTextAsync(filename, entryText.Text);
            appliquerButton.IsEnabled = false;
            labelMesage.Text = "Texte sauvegardé dans le fichier temp.txt";
        }

	}
}