﻿

namespace EliteHaven.Infrastructure.Repository;

public class VillaRepository : Repository<Villa>, IVillaRepository
{
    // Injection of this type.
    private readonly ApplicationDbContext context;

    // Passing context to base class as it needs this type.
    public VillaRepository(ApplicationDbContext context) : base(context)
    {
        this.context = context;
    }

    public void UpdateVilla(Villa villa)
    {
        context.Update(villa);
    }
}
