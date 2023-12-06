using Firebase.Database;
using Newtonsoft.Json;

namespace Maui02CollectionView;

public partial class AddPage : ContentPage
{
    FirebaseClient client = new FirebaseClient("https://dam-players-default-rtdb.europe-west1.firebasedatabase.app/");

    public AddPage()
	{
		InitializeComponent();
		List<Object> countries = new List<Object>()
		{
			new {Name = "Argentina", File = "argentina.png"},
			new {Name = "Spain", File = "spain.png"},
			new {Name = "United Kingdom", File = "uk.png"},
			//new {Name = "Dotnet", File = "dotnet_bot.png"}
		};

		CmbCountry.ItemsSource = countries; //Cargar el comboBox con la colección recién creada de países
		CmbCountry.SelectedValuePath = "File";
		CmbCountry.TextMemberPath = "Name";
		CmbCountry.DisplayMemberPath = "Name";
	}

    private async void BtnSave_Clicked(object sender, EventArgs e)
    {
		Player player = new Player();
		player.FirstName = EntFirstName.Text;
		player.LastName = EntLastName.Text;
		player.ProfileImage = EntProfileImage.Text;
		player.PlayerImage = EntPlayerImage.Text;

		dynamic d = CmbCountry.SelectedItem;
		string strCountry = d.Name;
		player.Country = strCountry;
		player.CountryFlag = d.File;

		string strPlayer = JsonConvert.SerializeObject(player);
		await client.Child("Player").PostAsync(strPlayer);
		await Navigation.PopAsync();
    }
}