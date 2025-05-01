namespace EliteHaven.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

   
    public DbSet<Villa> Villas { get; set; }
    public DbSet<VillaNumber> VillaNumbers { get; set; }
    public DbSet<Amenity> Amenities { get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Villas with realistic data
        modelBuilder.Entity<Villa>().HasData(
            new Villa
            {
                Id = 1,
                Name = "Royal Palm Villa",
                Description = "A luxurious villa with panoramic ocean views, private pool, and modern interiors ideal for families or honeymooners.",
                ImageUrl = "https://images.pexels.com/photos/261102/pexels-photo-261102.jpeg", // Unsplash image
                Occupancy = 4,
                Price = 450,
                Sqft = 800,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Villa
            {
                Id = 2,
                Name = "Sunset Lagoon Villa",
                Description = "Located by the water, this premium villa features a plunge pool, open-concept living space, and romantic sunset views.",
                ImageUrl = "https://images.pexels.com/photos/261327/pexels-photo-261327.jpeg", // Unsplash image
                Occupancy = 3,
                Price = 380,
                Sqft = 650,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Villa
            {
                Id = 3,
                Name = "Haven Beach Villa",
                Description = "A modern beachfront villa with jacuzzi, king-size beds, smart appliances, and private access to the beach.",
                ImageUrl = "https://media.istockphoto.com/id/2110310187/photo/luxury-tropical-pool-villa-at-dusk.jpg?s=2048x2048&w=is&k=20&c=wnkTbRt-4YxghsD9_T_M84GdpxKDCzxAfvHtN130mnc=", // Unsplash image
                Occupancy = 5,
                Price = 520,
                Sqft = 900,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },new Villa
            {
                Id = 4,
                Name = "Sunset Paradise Villa",
                Description = "Beautiful beachfront villa with direct access to white sandy beaches, featuring a tropical garden and outdoor shower.",
                ImageUrl = "https://images.pexels.com/photos/258154/pexels-photo-258154.jpeg",
                Occupancy = 4,
                Price = 650,
                Sqft = 1200,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }, new Villa
            {
                Id = 5,
                Name = "Arctic Glass Dome",
                Description = "Unique transparent dome villa for northern lights viewing, with heated floors, private sauna, and husky experiences available.",
                ImageUrl = "https://images.pexels.com/photos/753626/pexels-photo-753626.jpeg",
                Occupancy = 3,
                Price = 900,
                Sqft = 600,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            },
            new Villa
            {
                Id = 6,
                Name = "Underwater Bungalow",
                Description = "Breathtaking underwater bedroom with 360° ocean views, private submarine tours, and marine biologist guided snorkeling.",
                ImageUrl = "https://images.pexels.com/photos/338504/pexels-photo-338504.jpeg",
                Occupancy = 2,
                Price = 2500,
                Sqft = 900,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            }
        );

        // Villa Numbers
        modelBuilder.Entity<VillaNumber>().HasData(
            new VillaNumber { Villa_Number = 101, VillaId = 1 },
            new VillaNumber { Villa_Number = 102, VillaId = 1 },
            new VillaNumber { Villa_Number = 201, VillaId = 2 },
            new VillaNumber { Villa_Number = 202, VillaId = 2 },
            new VillaNumber { Villa_Number = 301, VillaId = 3 },
            new VillaNumber { Villa_Number = 302, VillaId = 3 }
        );

        // Amenities
        modelBuilder.Entity<Amenity>().HasData(
            new Amenity { Id = 1, VillaId = 1, Name = "Infinity Pool" },
            new Amenity { Id = 2, VillaId = 1, Name = "Underwater bedroom, Private submarine, Coral reef access, Marine life expert guide" },
            new Amenity { Id = 3, VillaId = 1, Name = "Smart TV with Netflix" },
            new Amenity { Id = 4, VillaId = 2, Name = "Plunge Pool" },
            new Amenity { Id = 5, VillaId = 2, Name = "Mini Bar & Coffee Maker" },
            new Amenity { Id = 6, VillaId = 2, Name = "Private Patio" },
            new Amenity { Id = 7, VillaId = 3, Name = "Beach Access" },
            new Amenity { Id = 8, VillaId = 3, Name = "Jacuzzi" },
            new Amenity { Id = 9, VillaId = 3, Name = "In-Room Breakfast" }
        );
    }

}
