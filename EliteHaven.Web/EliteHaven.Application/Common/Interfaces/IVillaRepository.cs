namespace EliteHaven.Application.Common.Interfaces;

public interface IVillaRepository : IRepository<Villa>
{
    public void UpdateVilla(Villa villa);
}
