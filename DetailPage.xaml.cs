namespace Maui02CollectionView;

public partial class DetailPage : ContentPage
{
	public DetailPage(Player player)
	{
		InitializeComponent();
		ImgProfile.Source = player.ProfileImage;
		LblFirstName.Text = player.FirstName;
		LblLastName.Text = player.LastName;
		ImgCountryFlag.Source = player.CountryFlag;
		LblCountry.Text = player.Country;
		ImgPlayer.Source = player.PlayerImage;
	}
}