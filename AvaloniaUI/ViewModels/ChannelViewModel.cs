using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using MediaCenter.Model;
using OlimpoMediaCenter.AvaloniaUI.ViewModels;
using ReactiveUI;

namespace AvaloniaUI.ViewModels
{
    public class ChannelViewModel : ViewModelBase
    {
        private Channel _channel;
        private string _name;
        private Bitmap? _logo;
        private bool _highlight;

        public string Name
        {
            get => this._name;
            set => this.RaiseAndSetIfChanged(ref this._name, value);
        }

        public Bitmap? Logo
        {
            get => this._logo;
            set => this.RaiseAndSetIfChanged(ref this._logo, value);
        }

        public bool Highlight 
        { 
            get => _highlight; 
            set => this.RaiseAndSetIfChanged(ref this._highlight, value);
        }

        public ChannelViewModel(Channel channel)
        {
            this._channel = channel;

            this.Name = channel.Name;

            Task.Run(async () =>
            {
                var httpClient = new HttpClient();
                var data = await httpClient.GetByteArrayAsync(this._channel.Logo);

                this.Logo = Bitmap.DecodeToWidth(new MemoryStream(data), 400);
            });

        }
    }
}
