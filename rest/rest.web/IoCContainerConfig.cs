namespace rest.web {

    internal class IoCContainerConfig {

        private readonly IServiceProvider _serviceProvider;

        public IoCContainerConfig() {
            var services = new ServiceCollection();

            // Add services here

            _serviceProvider = services.BuildServiceProvider();
        }
    }
}
