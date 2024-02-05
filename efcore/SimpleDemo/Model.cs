using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbConnectionString { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbConnectionString = "PORT=5432;DATABASE=huadz;HOST=192.168.0.241;PASSWORD=ynzp123;USER ID=postgres;";
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(DbConnectionString);
}

[Table("blog")]
public class Blog
{
    [Column("blog_id")]
    public int BlogId { get; set; }
    [Column("url")]
    public string Url { get; set; } = null!;

    public List<Post> Posts { get; } = new();
}

[Table("post")]
public class Post
{
    [Column("post_id")]
    public int PostId { get; set; }
    [Column("title")]
    public string Title { get; set; } = null!;
    [Column("content")]
    public string Content { get; set; } = null!;
    [Column("blog_id")]
    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}