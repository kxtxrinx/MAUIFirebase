using System.Collections.ObjectModel;
using Firebase.Database;

namespace Maui02CollectionView
{
    public partial class MainPage : ContentPage
    {
        FirebaseClient client = new FirebaseClient("https://dam-players-default-rtdb.europe-west1.firebasedatabase.app/");
        public ObservableCollection<Player> Players { get; set; } =
            new ObservableCollection<Player>();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;
            var collection = client.Child("Player").
                AsObservable<Player>().Subscribe((item) =>
                {
                    if (item.Object != null)
                    {
                        Players.Add(item.Object);
                    }
                });
        }

        private void ContentPage_Loaded(object sender, EventArgs e)
        {
            /*
            ObservableCollection<Player> players = new ObservableCollection<Player>();

            players.Add(new Player
            {
                PlayerId = 1,
                FirstName = "Lionel",
                LastName = "Messi",
                ProfileImage = "https://fcb-abj-pre.s3.amazonaws.com/img/jugadors/MESSI.jpg",
                PlayerImage = "https://image.ondacero.es/clipping/cmsimages01/2023/06/13/D2A4CC75-E672-4A54-B325-1611051ED976/messi-principio-ire-proximo-mundial_97.jpg",
                Country = "Argentina",
                CountryFlag = "argentina.png"
            });
            players.Add(new Player
            {
                PlayerId = 2,
                FirstName = "Aitana",
                LastName = "Bonmatí",
                ProfileImage = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/bd/2019-05-18_Fu%C3%9Fball%2C_Frauen%2C_UEFA_Women%27s_Champions_League%2C_Olympique_Lyonnais_-_FC_Barcelona_StP_0032_LR10_by_Stepro_%28cropped%29.jpg/225px-2019-05-18_Fu%C3%9Fball%2C_Frauen%2C_UEFA_Women%27s_Champions_League%2C_Olympique_Lyonnais_-_FC_Barcelona_StP_0032_LR10_by_Stepro_%28cropped%29.jpg",
                PlayerImage = "https://www.editoriallacalle.com/wp-content/uploads/2023/07/aitana-seleccion-736x480.png",
                Country = "España",
                CountryFlag = "spain.png"
            });
            players.Add(new Player
            {
                PlayerId = 3,
                FirstName = "Jude",
                LastName = "Bellingham",
                ProfileImage = "https://b.fssta.com/uploads/application/soccer/headshots/71310.png",
                PlayerImage = "https://assets-es.imgfoot.com/media/cache/1200x675/epaliveseven059352.jpg",
                Country = "Reino Unido",
                CountryFlag = "uk.png"
            });
            players.Add(new Player
            {
                PlayerId = 4,
                FirstName = "Alexia",
                LastName = "Putellas",
                ProfileImage = "https://www.enciclopedia.cat/sites/default/files/2021-11/Alexia_Putellas.png",
                PlayerImage = "https://images2.minutemediacdn.com/image/upload/c_crop,w_5084,h_2859,x_0,y_204/c_fill,w_1080,ar_16:9,f_auto,q_auto,g_auto/images%2FGettyImages%2Fmmsport%2F90min_es_international_web%2F01gfkc8cr85zngs87g3j.jpg",
                Country = "España",
                CountryFlag = "spain.png"
            });

            CtvPlayers.ItemsSource = players;
            */
        }

        private async void CtvPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Player player = (Player) CtvPlayers.SelectedItem;
            await Navigation.PushAsync(new DetailPage(player));
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            Player player = (Player)((VisualElement)sender).BindingContext;
            await Navigation.PushAsync(new DetailPage(player));
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage());
        }
    }

}
