using Autofac;
using GreatCalculator.Client.Views;

namespace GreatCalculator.Client.Modules
{
    internal class ViewModelsModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<MainWindowView>()
                .AsSelf()
                .SingleInstance();
            builder
                .RegisterType<MainWindowViewModel>()
                .AsSelf()
                .SingleInstance();
        }
    }
}
