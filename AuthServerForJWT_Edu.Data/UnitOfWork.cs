using AuthServerForJWT_Edu.Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace AuthServerForJWT_Edu.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _context;

    public UnitOfWork(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommmitAsync()
    {
        await _context.SaveChangesAsync();
    }
}
