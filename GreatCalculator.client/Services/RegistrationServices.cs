﻿using Autofac;
using Splat;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatCalculator.Services
{
    /// <summary>
	/// The registration service.
	/// </summary>
	static class RegistrationService
    {
        /// <summary>
        /// Creates the container.
        /// </summary>
        /// <param name="appServices">The app services.</param>
        /// <returns>An IContainer.</returns>
        public static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(GreatCalculator.Client.App).Assembly);

            var container = builder.Build();

            return container;
        }
    }
}
