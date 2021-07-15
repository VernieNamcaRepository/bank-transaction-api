using BankTransaction.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankTransaction.Infrastructure.Data
{
    public class BankTransactionContext : DbContext
    {
        public BankTransactionContext(DbContextOptions<BankTransactionContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>(ConfigureAccount);
            builder.Entity<Transaction>(ConfigureTransaction);
        }

        private void ConfigureAccount(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");

            builder.HasKey(x => x.AccountNumber);

            builder.Property(x => x.AccountName).IsRequired(true);
            builder.Property(x => x.CurrentBalance).HasColumnType("decimal(16,2)").IsRequired(true);
            builder.Property(x => x.DateCreated).IsRequired(true);
        }

        private void ConfigureTransaction(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.AccountNumber).IsRequired(true);
            builder.Property(x => x.TransactionType).IsRequired(true);
            builder.Property(x => x.PreviousBalance).HasColumnType("decimal(16,2)").IsRequired(true);
            builder.Property(x => x.Amount).HasColumnType("decimal(16,2)").IsRequired(true);
            builder.Property(x => x.TransactionDate).IsRequired(true);
        }
    }
}
