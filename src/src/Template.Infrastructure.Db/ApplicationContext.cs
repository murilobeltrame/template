using Microsoft.EntityFrameworkCore;

namespace Template.Infrastructure.Db;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
}
