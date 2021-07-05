using System;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace AvaloniaUI.Controls
{
    public class ChannelButton : RadioButton, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ToggleButton);
    }
}
