#region copyright notice

// This file is part of caliburn.micro.reactiveui.sample.

// caliburn.micro.reactiveui.sample is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Foobar is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with caliburn.micro.reactiveui.sample.  If not, see <http://www.gnu.org/licenses/>.

#endregion

namespace CaliburnMicroReactiveUI.Sample.Commands
{
    using Caliburn.Micro;
    using Services;
    using System;
    using System.Collections.Generic;
    using ViewModels;
    using Views;

    public class AppBootstrapper : Bootstrapper<ShellViewModel> 
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Start();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.PerRequest<IShell, ShellViewModel>();
            container.PerRequest<IMessageBoxService, MessageBoxService>();
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = container.GetInstance(service, key);
            if (instance != null)
                return instance;

            throw new InvalidOperationException("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShell>();
        }
    }
}
