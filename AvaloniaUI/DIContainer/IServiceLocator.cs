using Microsoft.Extensions.DependencyInjection;

namespace OlimpoMediaCenter.AvaloniaUI.DIContainer
{
    public interface IServiceLocator
    {
        ServiceCollection ServiceCollection { get; set; }

        ServiceProvider ServiceProvider { get; }
    }
}
