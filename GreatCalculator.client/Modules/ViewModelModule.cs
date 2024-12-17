using Autofac;
using GreatCalculator.Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
