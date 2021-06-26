using MediaCenter.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaUI.DbServices
{
    public class ChannelsContext : DbContext, IChannelsContext
    {
        public DbSet<Channel> Channels { get; set; }

        public DbSet<ChannelUrl> ChannelUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite("Data Source=Channels.db");
    }
}
