using Microsoft.Extensions.DependencyInjection;

namespace PM2E120210130074Prueba
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new CalculadoradeEnvios());
        }
    }
}