using System.Collections.ObjectModel;
using OlimpoMediaCenter.AvaloniaUI.ViewModels;

namespace AvaloniaUI.ViewModels
{
    public class ChannelsRowViewModel : ViewModelBase
    {
        public int Id { get; set; }

        public ObservableCollection<ChannelViewModel> ChannelsRow { get; private set; }

        public ChannelsRowViewModel(int rowId)
        {
            this.Id = rowId;
            this.ChannelsRow = new ObservableCollection<ChannelViewModel>();
        }
    }
}
