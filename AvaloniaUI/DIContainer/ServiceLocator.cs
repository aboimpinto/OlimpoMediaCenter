using Microsoft.Extensions.DependencyInjection;

namespace OlimpoMediaCenter.AvaloniaUI.DIContainer
{
    public class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator _current = new ServiceLocator();

        public ServiceCollection ServiceCollection { get; set; }

        public ServiceProvider ServiceProvider => this.ServiceCollection.BuildServiceProvider();

        public static IServiceLocator Current
        {
            get
            {
                return _current;
            }
        }

        static ServiceLocator()
        {
            _current.ServiceCollection.AddSingleton<IServiceLocator>(_current);
        }

        public ServiceLocator()
        {
            this.ServiceCollection = new ServiceCollection();
        }
    }
}
