using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext{
    public DbSet<Produto> Produtos{get; set;}
    public DbSet<Cliente> Clientes{get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlite("Data Source=produtos.db");
    }

}

