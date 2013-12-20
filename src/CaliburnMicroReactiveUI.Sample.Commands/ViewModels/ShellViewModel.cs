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

namespace CaliburnMicroReactiveUI.Sample.Commands.ViewModels
{
    using CaliburnMicroReactiveUI.Sample.Commands.Views;
    using Caliburn.Micro.ReactiveUI;
    using ReactiveUI;
    using System;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;
    using System.Threading;

    public class ShellViewModel : ReactivePropertyChangedBase, IShell
    {
        private string personName;

        public ShellViewModel(IMessageBoxService messageBoxService)
        {
            DisplayCommand = new ReactiveCommand(this.WhenAny(x => x.PersonName, x => !string.IsNullOrEmpty(x.Value)));
            DisplayCommand.Subscribe(_ => messageBoxService.ShowMessageBox("You clicked on DisplayCommand: Name is " + PersonName));

            var localProgress = new Subject<int>();
            localProgress.ToProperty(this, x => x.Progress, out progress);

            StartAsyncCommand = new ReactiveCommand();
            StartAsyncCommand.RegisterAsyncAction(_ =>
            {
                var currentProgress = 0;
                localProgress.OnNext(currentProgress);
                while (currentProgress <= 100)
                {
                    localProgress.OnNext(currentProgress += 10);
                    Thread.Sleep(100);
                }
            });
        }

        public IReactiveCommand DisplayCommand { get; protected set; }

        public string PersonName
        {
            get { return personName; }
            set
            {
                this.RaiseAndSetIfChanged(ref personName, value);
            }
        }

        private ObservableAsPropertyHelper<int> progress;
        public int Progress
        {
            get { return progress.Value; }
        }

        public IReactiveCommand StartAsyncCommand { get; protected set; }
    }
}