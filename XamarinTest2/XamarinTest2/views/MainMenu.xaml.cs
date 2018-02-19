using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest2.objects;

namespace XamarinTest2.views
{
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Recherche", Icon = "menu_recherche.png", TargetType = typeof(Search) },
                new MainMenuItem() { Title = "Emotions", Icon = "menu_emotions.png", TargetType = typeof(RateAppPage) },
                new MainMenuItem() { Title = "Posts", Icon = "menu_posts.png", TargetType = typeof(RestPosts)},
                new MainMenuItem() {Title = "Sauvegarder", Icon = "menu_sauvegarder.png", TargetType = typeof(SaveFileView)},
                new MainMenuItem() { Title = "Charger", Icon = "menu_charger.png", TargetType = typeof(LoadFileView)},
                new MainMenuItem() { Title = "BDD", Icon = "menu_bdd.png", TargetType = typeof(PostSql)}
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new NotImplementedPage());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                if (item.Title.Equals("Recherche"))
                {
                    Detail = new NavigationPage(new Search());
                }
                else if (item.Title.Equals("Emotions"))
                {
                    Detail = new NavigationPage(new RateAppPage());
                }
                else if (item.Title.Equals("Posts"))
                {
                    Detail = new NavigationPage(new RestPosts());
                }
                else if (item.Title.Equals("Sauvegarder"))
                {
                    Detail = new NavigationPage(new SaveFileView());
                }
                else if (item.Title.Equals("Charger"))
                {
                    Detail = new NavigationPage(new LoadFileView());
                }
                else if (item.Title.Equals("BDD"))
                {
                    Detail = new NavigationPage(new PostSql());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}