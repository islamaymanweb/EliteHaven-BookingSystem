namespace EliteHaven.Application;


public interface IUnitOfWork
{

    public IVillaRepository Villa { get; }


    public IVillaNumberRepository VillaNumber { get; }


    public IAmenityRepository Amenity { get; }


    public IBookingRepository Booking { get; }


    public IApplicationUserRepository ApplicationUser { get; }


    public void Save();
}
