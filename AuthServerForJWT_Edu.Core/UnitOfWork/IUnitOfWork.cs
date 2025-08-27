namespace AuthServerForJWT_Edu.Core.UnitOfWork;

public interface IUnitOfWork
{
    Task CommmitAsync();

    void Commit();
}