using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InternetProvider;

public partial class InternetProviderContext : DbContext
{
    public InternetProviderContext()
    {
    }

    public InternetProviderContext(DbContextOptions<InternetProviderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Clientum> ClientAs { get; set; }

    public virtual DbSet<Clientview> Clientviews { get; set; }

    public virtual DbSet<ClientviewTechno> ClientviewTechnos { get; set; }

    public virtual DbSet<Deal> Deals { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Tarrif> Tarrifs { get; set; }

    public virtual DbSet<Traffic> Traffics { get; set; }

    public virtual DbSet<Trafficview> Trafficviews { get; set; }

    public virtual DbSet<TrafficviewTechno> TrafficviewTechnos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=internet_provider;Username=postgres;Password=bonanza623");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("tablefunc");

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.НомерКлиента).HasName("Клиент_pkey");

            entity.ToTable("Client");

            entity.HasIndex(e => e.НомерДоговора, "fki_Договор");

            entity.Property(e => e.НомерКлиента)
                .HasDefaultValueSql("nextval('\"Клиент_Номер клиента_seq\"'::regclass)")
                .HasColumnName("Номер клиента");
            entity.Property(e => e.Адрес).HasMaxLength(50);
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Отчество).HasMaxLength(30);
            entity.Property(e => e.Фамилия).HasMaxLength(30);
            entity.Property(e => e.ЭлектроннаяПочта)
                .HasMaxLength(50)
                .HasColumnName("Электронная почта");

            entity.HasOne(d => d.НомерДоговораNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.НомерДоговора)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Договор");
        });

        modelBuilder.Entity<Clientum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ClientA");

            entity.Property(e => e.Адрес).HasMaxLength(50);
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.НомерКлиента)
                .HasDefaultValueSql("nextval('\"Клиент_Номер клиента_seq\"'::regclass)")
                .HasColumnName("Номер клиента");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Отчество).HasMaxLength(30);
            entity.Property(e => e.Фамилия).HasMaxLength(30);
            entity.Property(e => e.ЭлектроннаяПочта)
                .HasMaxLength(50)
                .HasColumnName("Электронная почта");
        });

        modelBuilder.Entity<Clientview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("clientview");

            entity.Property(e => e.Адрес).HasMaxLength(50);
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.НомерКлиента).HasColumnName("Номер клиента");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Отчество).HasMaxLength(30);
            entity.Property(e => e.Фамилия).HasMaxLength(30);
            entity.Property(e => e.ЭлектроннаяПочта)
                .HasMaxLength(50)
                .HasColumnName("Электронная почта");
        });

        modelBuilder.Entity<ClientviewTechno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("clientview_techno");

            entity.Property(e => e.Адрес).HasMaxLength(50);
            entity.Property(e => e.ДатаРождения).HasColumnName("Дата рождения");
            entity.Property(e => e.Имя).HasMaxLength(30);
            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.НомерКлиента).HasColumnName("Номер клиента");
            entity.Property(e => e.НомерТарифа).HasColumnName("Номер тарифа");
            entity.Property(e => e.НомерТелефона)
                .HasMaxLength(20)
                .IsFixedLength()
                .HasColumnName("Номер телефона");
            entity.Property(e => e.Отчество).HasMaxLength(30);
            entity.Property(e => e.Фамилия).HasMaxLength(30);
            entity.Property(e => e.ЭлектроннаяПочта)
                .HasMaxLength(50)
                .HasColumnName("Электронная почта");
        });

        modelBuilder.Entity<Deal>(entity =>
        {
            entity.HasKey(e => e.НомерДоговора).HasName("Договор_pkey");

            entity.ToTable("Deal");

            entity.Property(e => e.НомерДоговора)
                .HasDefaultValueSql("nextval('\"Договор_Номер договора_seq\"'::regclass)")
                .HasColumnName("Номер договора");
            entity.Property(e => e.АрендаРоутера).HasColumnName("Аренда роутера");
            entity.Property(e => e.ДатаЗаключения).HasColumnName("Дата заключения");
            entity.Property(e => e.НомерТарифа).HasColumnName("Номер тарифа");
            entity.Property(e => e.СрокДействия).HasColumnName("Срок действия");
            entity.Property(e => e.ЦифровоеТв).HasColumnName("Цифровое ТВ");

            entity.HasOne(d => d.НомерТарифаNavigation).WithMany(p => p.Deals)
                .HasForeignKey(d => d.НомерТарифа)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Договор_Номер тарифа_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.НомерПлатежа).HasName("Платеж_pkey");

            entity.ToTable("Payment");

            entity.Property(e => e.НомерПлатежа)
                .ValueGeneratedNever()
                .HasColumnName("Номер платежа");
            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.Сумма).HasColumnType("money");

            entity.HasOne(d => d.НомерДоговораNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.НомерДоговора)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Платеж_Номер договора_fkey");
        });

        modelBuilder.Entity<Tarrif>(entity =>
        {
            entity.HasKey(e => e.НомерТарифа).HasName("Тариф_pkey");

            entity.ToTable("Tarrif");

            entity.Property(e => e.НомерТарифа)
                .HasDefaultValueSql("nextval('\"Тариф_Номер тарифа_seq\"'::regclass)")
                .HasColumnName("Номер тарифа");
            entity.Property(e => e.Название).HasMaxLength(20);
            entity.Property(e => e.СкоростьМбитС).HasColumnName("Скорость (мбит/с)");
            entity.Property(e => e.Цена).HasColumnType("money");
        });

        modelBuilder.Entity<Traffic>(entity =>
        {
            entity.HasKey(e => e.Запись).HasName("Трафик_pkey");

            entity.ToTable("Traffic");

            entity.Property(e => e.Запись).ValueGeneratedNever();
            entity.Property(e => e.НомерКлиента).HasColumnName("Номер клиента");
            entity.Property(e => e.ОбъёмМбайт).HasColumnName("Объём (мбайт)");

            entity.HasOne(d => d.НомерКлиентаNavigation).WithMany(p => p.Traffics)
                .HasForeignKey(d => d.НомерКлиента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Трафик_Номер клиента_fkey");
        });

        modelBuilder.Entity<Trafficview>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("trafficview");

            entity.Property(e => e.НомерКлиента).HasColumnName("Номер клиента");
            entity.Property(e => e.ОбъёмМбайт).HasColumnName("Объём (мбайт)");
        });

        modelBuilder.Entity<TrafficviewTechno>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("trafficview_techno");

            entity.Property(e => e.НомерДоговора).HasColumnName("Номер договора");
            entity.Property(e => e.НомерКлиента).HasColumnName("Номер клиента");
            entity.Property(e => e.ОбъёмМбайт).HasColumnName("Объём (мбайт)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
