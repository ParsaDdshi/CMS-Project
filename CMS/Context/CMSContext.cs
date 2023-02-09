using CMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CMS.Context
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options) : base (options) {}

        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryToItem> CategoriesToItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavouriteItem> UserFavouriteItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryToItem>()
                .HasKey(k => new { k.CategoryId, k.ItemId });

            modelBuilder.Entity<UserFavouriteItem>()
                .HasKey(k => new { k.UserId, k.ItemId });

            #region Category Seed Date
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    CategoryId = 1,
                    CategoryName = "Category - 1"
                },
                new Category()
                {
                    CategoryId = 2,
                    CategoryName = "Category - 2"
                },
                new Category()
                {
                    CategoryId = 3,
                    CategoryName = "Category - 3"
                }
            );
            #endregion

            #region Item Seed Data
            modelBuilder.Entity<Item>().HasData(
                new Item()
                {
                    ItemId = 1,
                    Title = "Item - 1",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 55
                },
                new Item()
                {
                    ItemId = 2,
                    Title = "Item - 2",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 68
                },
                new Item()
                {
                    ItemId = 3,
                    Title = "Item - 3",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 73
                },
                new Item()
                {
                    ItemId = 4,
                    Title = "Item - 4",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 22
                },
                new Item()
                {
                    ItemId = 5,
                    Title = "Item - 5",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 35
                },
                new Item()
                {
                    ItemId = 6,
                    Title = "Item - 6",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 88
                },
                new Item()
                {
                    ItemId = 7,
                    Title = "Item - 7",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 53
                },
                new Item()
                {
                    ItemId = 8,
                    Title = "Item - 8",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 20
                },
                new Item()
                {
                    ItemId = 9,
                    Title = "Item - 9",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 15
                },
                new Item()
                {
                    ItemId = 10,
                    Title = "Item - 10",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 100
                },
                new Item()
                {
                    ItemId = 11,
                    Title = "Item - 11",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 49
                },
                new Item()
                {
                    ItemId = 12,
                    Title = "Item - 12",
                    Text = " Blanditiis voluptate odit ex error ea sed officiis deserunt. Cupiditate non consequatur et doloremque consequuntur. Accusantium labore reprehenderit error temporibus saepe perferendis fuga doloribus vero. Qui omnis quo sit. Dolorem architecto eum et quos deleniti officia qui.\r\n\r\n    Aut eum totam accusantium voluptatem.\r\n    Assumenda et porro nisi nihil nesciunt voluptatibus.\r\n    Ullamco laboris nisi ut aliquip ex ea\r\n\r\nEst reprehenderit voluptatem necessitatibus asperiores neque sed ea illo. Deleniti quam sequi optio iste veniam repellat odit. Aut pariatur itaque nesciunt fuga.\r\n\r\nSunt rem odit accusantium omnis perspiciatis officia. Laboriosam aut consequuntur recusandae mollitia doloremque est architecto cupiditate ullam. Quia est ut occaecati fuga. Distinctio ex repellendus eveniet velit sint quia sapiente cumque. Et ipsa perferendis ut nihil. Laboriosam vel voluptates tenetur nostrum. Eaque iusto cupiditate et totam et quia dolorum in. Sunt molestiae ipsum at consequatur vero. Architecto ut pariatur autem ad non cumque nesciunt qui maxime. Sunt eum quia impedit dolore alias explicabo ea. ",
                    CreateDate = DateTime.Now,
                    Views = 18
                }
            );
            #endregion

            #region CategoryToItem Seed Data
            modelBuilder.Entity<CategoryToItem>().HasData(
                new CategoryToItem() { CategoryId = 1, ItemId = 1},
                new CategoryToItem() { CategoryId = 3, ItemId = 2 },
                new CategoryToItem() { CategoryId = 2, ItemId = 3 },
                new CategoryToItem() { CategoryId = 1, ItemId = 4 },
                new CategoryToItem() { CategoryId = 1, ItemId = 5 },
                new CategoryToItem() { CategoryId = 3, ItemId = 6 },
                new CategoryToItem() { CategoryId = 2, ItemId = 7 },
                new CategoryToItem() { CategoryId = 1, ItemId = 8 },
                new CategoryToItem() { CategoryId = 2, ItemId = 9 },
                new CategoryToItem() { CategoryId = 2, ItemId = 10 },
                new CategoryToItem() { CategoryId = 3, ItemId = 11 },
                new CategoryToItem() { CategoryId = 3, ItemId = 12 },
                new CategoryToItem() { CategoryId = 2, ItemId = 1 },
                new CategoryToItem() { CategoryId = 1, ItemId = 2 },
                new CategoryToItem() { CategoryId = 3, ItemId = 3 },
                new CategoryToItem() { CategoryId = 3, ItemId = 4 },
                new CategoryToItem() { CategoryId = 3, ItemId = 10 },
                new CategoryToItem() { CategoryId = 2, ItemId = 11 },
                new CategoryToItem() { CategoryId = 1, ItemId = 12 }
            );
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
