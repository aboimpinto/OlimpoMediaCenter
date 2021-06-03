using Microsoft.Extensions.DependencyInjection;

namespace OlimpoMediaCenter.AvaloniaUI.DIContainer
{
    public class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator _current;

        public ServiceCollection ServiceCollection { get; set; }

        public ServiceProvider ServiceProvider => this.ServiceCollection.BuildServiceProvider();

        public static IServiceLocator Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new ServiceLocator();
                    _current.ServiceCollection.AddSingleton<IServiceLocator>(_current);
                }

                return _current;
            }
        }

        public ServiceLocator()
        {
            this.ServiceCollection = new ServiceCollection();
        }
    }
}
