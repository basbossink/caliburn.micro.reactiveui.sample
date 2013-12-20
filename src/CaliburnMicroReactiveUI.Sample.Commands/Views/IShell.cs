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

namespace CaliburnMicroReactiveUI.Sample.Commands.Views
{
    using ReactiveUI; 

    public interface IShell
    {
        string PersonName { get; set; }
        int Progress { get; }
        IReactiveCommand DisplayCommand { get; }
        IReactiveCommand StartAsyncCommand { get; }
    }
}
