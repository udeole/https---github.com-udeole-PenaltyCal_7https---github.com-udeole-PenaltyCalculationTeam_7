using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PenaltyCal_7.Models;

public partial class PenaltyCalContext : DbContext  
{
    public PenaltyCalContext()
    {
    }

    public PenaltyCalContext(DbContextOptions<PenaltyCalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HolidayCalender> HolidayCalenders { get; set; }

    public virtual DbSet<LoginUser> LoginUsers { get; set; }

    public virtual DbSet<SecurityPenaltyRate> SecurityPenaltyRates { get; set; }

    public virtual DbSet<SecurityPrice> SecurityPrices { get; set; }

    public virtual DbSet<SignupUser> SignupUsers { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }
    public object Securities { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=PenaltyCal;Username=postgres;Password=Priti@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HolidayCalender>(entity =>
        {
            entity.HasKey(e => e.HolidayId).HasName("holiday_calender_pkey");

            entity.ToTable("holiday_calender");

            entity.Property(e => e.HolidayId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("holiday_id");
            entity.Property(e => e.CntlUserid)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("cntl_userid");
            entity.Property(e => e.Country)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("country");
            entity.Property(e => e.Description)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("description");
            entity.Property(e => e.HolidayDate).HasColumnName("holiday_date");
            entity.Property(e => e.LastUpdatedDate).HasColumnName("last_updated_date");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<LoginUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("login_user");

            entity.Property(e => e.CntlUserid)
                .HasMaxLength(1)
                .HasColumnName("cntl_userid");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("login_user_role_id_fkey");
        });

        modelBuilder.Entity<SecurityPenaltyRate>(entity =>
        {
            entity.HasKey(e => e.PenaltyId).HasName("Security Penalty rate_pkey");

            entity.ToTable("security_penalty_rate");

            entity.Property(e => e.PenaltyId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Penalty_id");
            entity.Property(e => e.Approval)
                .HasMaxLength(20)
                .HasDefaultValueSql("'approved'::character varying")
                .HasColumnName("approval");
            entity.Property(e => e.ApprovePenaltyRequired)
                .HasDefaultValueSql("250")
                .HasColumnName("approve_penalty_required");
            entity.Property(e => e.CntlTimestamp).HasColumnName("cntl_timestamp");
            entity.Property(e => e.CntlUserid)
                .HasColumnType("character varying(15)[]")
                .HasColumnName("cntl_userid");
            entity.Property(e => e.LastUpdatedDate).HasColumnName("Last Updated Date");
            entity.Property(e => e.PenaltyRate).HasColumnName("Penalty_Rate");
            entity.Property(e => e.ValidFromDate).HasColumnName("Valid From Date");
        });

        modelBuilder.Entity<SecurityPrice>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("Security Price_pkey");

            entity.ToTable("Security_Price");

            entity.Property(e => e.PriceId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("Price_id");
            entity.Property(e => e.CntlTimestamp).HasColumnName("cntl_timestamp");
            entity.Property(e => e.CntlUserid)
                .HasColumnType("character varying(15)[]")
                .HasColumnName("cntl_userid");
            entity.Property(e => e.IsinSecId)
                .HasColumnType("character varying(12)[]")
                .HasColumnName("ISIN SEC ID ");
            entity.Property(e => e.Poh).HasColumnName("POH");
            entity.Property(e => e.SecPrice).HasColumnName("Sec_price");
            entity.Property(e => e.ValidFromDate).HasColumnName("Valid from date");
        });

        modelBuilder.Entity<SignupUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("signup_user");

            entity.Property(e => e.CntlTimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cntl_timestamp");
            entity.Property(e => e.CntlUserid)
                .HasMaxLength(1)
                .HasColumnName("cntl_userid");
            entity.Property(e => e.FirstName)
                .HasMaxLength(30)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(30)
                .HasColumnName("last_name");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.TelephoneNumber)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("telephone_number");
            entity.Property(e => e.UserId)
                .HasMaxLength(10)
                .HasColumnName("user_id");

            entity.HasOne(d => d.Role).WithMany()
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("signup_user_role_id_fkey");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("transaction_pkey");

            entity.ToTable("transaction");

            entity.Property(e => e.TransactionId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("transaction_id");
            entity.Property(e => e.CalendarId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("calendar_id");
            entity.Property(e => e.CntlTimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cntl_timestamp");
            entity.Property(e => e.CntlUserid)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("cntl_userid");
            entity.Property(e => e.CounterPartyId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("counter_party_id");
            entity.Property(e => e.CounterPartyRoleCd)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("counter_party_role_cd");
            entity.Property(e => e.FailingPartyRoleCd)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("failing_party_role_cd");
            entity.Property(e => e.InstructionTypeCode)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("instruction_type_code");
            entity.Property(e => e.Isin)
                .HasMaxLength(12)
                .IsFixedLength()
                .HasColumnName("isin");
            entity.Property(e => e.MatchingReference)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("matching_reference");
            entity.Property(e => e.PartyId)
                .HasMaxLength(16)
                .IsFixedLength()
                .HasColumnName("party_id");
            entity.Property(e => e.PartyRoleCd)
                .HasMaxLength(6)
                .IsFixedLength()
                .HasColumnName("party_role_cd");
            entity.Property(e => e.PenaltyAmount)
                .HasPrecision(6, 3)
                .HasColumnName("penalty_amount");
            entity.Property(e => e.PlaceOfHoldingTechNumber).HasColumnName("place_of_holding_tech_number");
            entity.Property(e => e.SecurityQuantity).HasColumnName("security_quantity");
            entity.Property(e => e.SettlementCashAmount)
                .HasPrecision(6, 2)
                .HasColumnName("settlement_cash_amount");
            entity.Property(e => e.SettlementDate).HasColumnName("settlement_date");
            entity.Property(e => e.Sign)
                .HasColumnType("bit(1)")
                .HasColumnName("sign");
            entity.Property(e => e.TransactionTypeCode)
                .HasMaxLength(4)
                .IsFixedLength()
                .HasColumnName("transaction_type_code");
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("userrole_pkey");

            entity.ToTable("userrole");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.CntlTimestamp)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("cntl_timestamp");
            entity.Property(e => e.CntlUserId)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("cntl_user_id");
            entity.Property(e => e.RoleName)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("role_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
