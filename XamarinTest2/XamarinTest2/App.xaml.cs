using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinTest2.util;

namespace XamarinTest2
{
	public partial class App : Application
	{

        static SQLiteClient database;

		public App ()
		{
			InitializeComponent();

			MainPage = new XamarinTest2.views.MainMenu();
		}

        public static SQLiteClient Database
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteClient(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
