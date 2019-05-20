using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FillingStation
{
    public partial class StationsDBContext : DbContext
    {
        public StationsDBContext()
        {
        }

        public StationsDBContext(DbContextOptions<StationsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Fuel> Fuel { get; set; }
        public virtual DbSet<PaymentType> PaymentType { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderOfFuel> ProviderOfFuel { get; set; }
        public virtual DbSet<Selling> Selling { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<Storage> Storage { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=RefuelingStationsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId)
                    .HasColumnName("customerId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bonuses)
                    .HasColumnName("bonuses")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_User");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employeeId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.EmployeeAdress)
                    .HasColumnName("employeeAdress")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeePasport)
                    .HasColumnName("employeePasport")
                    .HasMaxLength(50);

                entity.Property(e => e.EmployeePhone)
                    .HasColumnName("employeePhone")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.EmployeeSalery)
                    .HasColumnName("employeeSalery")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StationId)
                    .IsRequired()
                    .HasColumnName("stationId")
                    .HasMaxLength(10);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.StationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Station");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_User");
            });

            modelBuilder.Entity<Fuel>(entity =>
            {
                entity.Property(e => e.FuelId)
                    .HasColumnName("fuelId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.FuelType)
                    .IsRequired()
                    .HasColumnName("fuelType")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.Property(e => e.PaymentId)
                    .HasColumnName("paymentId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.PaymentType1)
                    .IsRequired()
                    .HasColumnName("paymentType")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Provider>(entity =>
            {
                entity.Property(e => e.ProviderId)
                    .HasColumnName("providerId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProviderAddress)
                    .HasColumnName("providerAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.ProviderName)
                    .IsRequired()
                    .HasColumnName("providerName")
                    .HasMaxLength(50);

                entity.Property(e => e.ProviderPhone)
                    .HasColumnName("providerPhone")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<ProviderOfFuel>(entity =>
            {
                entity.HasKey(e => new { e.FuelId, e.ProviderId });

                entity.Property(e => e.FuelId)
                    .HasColumnName("fuelId")
                    .HasMaxLength(10);

                entity.Property(e => e.ProviderId)
                    .HasColumnName("providerId")
                    .HasMaxLength(10);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Fuel)
                    .WithMany(p => p.ProviderOfFuel)
                    .HasForeignKey(d => d.FuelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderOfFuel_Fuel");

                entity.HasOne(d => d.Provider)
                    .WithMany(p => p.ProviderOfFuel)
                    .HasForeignKey(d => d.ProviderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProviderOfFuel_Provider");
            });

            modelBuilder.Entity<Selling>(entity =>
            {
                entity.Property(e => e.SellingId)
                    .HasColumnName("sellingId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Bonus)
                    .HasColumnName("bonus")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CustomerId)
                    .IsRequired()
                    .HasColumnName("customerId")
                    .HasMaxLength(10);

                entity.Property(e => e.PaymentId)
                    .IsRequired()
                    .HasColumnName("paymentId")
                    .HasMaxLength(10);

                entity.Property(e => e.SellingAmount)
                    .HasColumnName("sellingAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.SellingDate)
                    .HasColumnName("sellingDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.SellingTotal)
                    .HasColumnName("sellingTotal")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StorageId)
                    .IsRequired()
                    .HasColumnName("storageId")
                    .HasMaxLength(10);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Selling)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_Customer");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Selling)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_PaymentType");

                entity.HasOne(d => d.Storage)
                    .WithMany(p => p.Selling)
                    .HasForeignKey(d => d.StorageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Selling_Storage");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.StationId)
                    .HasColumnName("stationId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.StationAddress)
                    .IsRequired()
                    .HasColumnName("stationAddress")
                    .HasMaxLength(50);

                entity.Property(e => e.StationName)
                    .IsRequired()
                    .HasColumnName("stationName")
                    .HasMaxLength(50);

                entity.Property(e => e.StationPhone)
                    .HasColumnName("stationPhone")
                    .HasColumnType("numeric(18, 0)");
            });

            modelBuilder.Entity<Storage>(entity =>
            {
                entity.Property(e => e.StorageId)
                    .HasColumnName("storageId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.FuelId)
                    .IsRequired()
                    .HasColumnName("fuelId")
                    .HasMaxLength(10);

                entity.Property(e => e.StationId)
                    .HasColumnName("stationId")
                    .HasMaxLength(10);

                entity.Property(e => e.StorageAmount)
                    .HasColumnName("storageAmount")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.StoragePrice)
                    .HasColumnName("storagePrice")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Fuel)
                    .WithMany(p => p.Storage)
                    .HasForeignKey(d => d.FuelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Storage_Fuel");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.Storage)
                    .HasForeignKey(d => d.StationId)
                    .HasConstraintName("FK_Storage_Station");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserEmail)
                    .IsRequired()
                    .HasColumnName("userEmail")
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(10);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(200);

                entity.Property(e => e.UserRoleId)
                    .IsRequired()
                    .HasColumnName("userRoleId")
                    .HasMaxLength(10);

                entity.Property(e => e.UserSurname)
                    .IsRequired()
                    .HasColumnName("userSurname")
                    .HasMaxLength(10);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.Property(e => e.UserRoleId)
                    .HasColumnName("userRoleId")
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.UserRole1)
                    .IsRequired()
                    .HasColumnName("userRole")
                    .HasMaxLength(20);
            });
        }
    }
}
