using MediaCenter.Model;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaUI.DbServices
{
    public interface IChannelsContext
    {
        DbSet<Channel> Channels { get; set; }

        DbSet<ChannelUrl> ChannelUrls { get; set; }
    }
}