namespace EliteHaven.Web.ViewModels;


public class HomeViewModel
{
    public IEnumerable<Villa>? VillaList { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime? CheckOutDate { get; set; }
    public int Nights { get; set; }
}
