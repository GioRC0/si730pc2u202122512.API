using _3._Data.model;
using Microsoft.EntityFrameworkCore;

namespace _3._Data.context;

public class FinTechDB: DbContext
{
    public FinTechDB(){}
    
    public FinTechDB(DbContextOptions<FinTechDB> options) : base(options){}
    
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=root;Database=fintech;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<FinancialTransaction>().ToTable("FinancialTransactions");
        builder.Entity<FinancialTransaction>().HasKey(f => f.Id);
        builder.Entity<FinancialTransaction>().Property(f => f.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        builder.Entity<FinancialTransaction>().Property(f => f.ReceiverId).IsRequired();
        builder.Entity<FinancialTransaction>().Property(f => f.UserName).IsRequired();
        builder.Entity<FinancialTransaction>().Property(f => f.Amount).IsRequired();
    }
}