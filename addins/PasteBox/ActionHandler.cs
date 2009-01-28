//
// ActionHandler.cs
// 
// Copyright (C) 2008 Eric Butler
//
// Authors:
//   Eric Butler <eric@extremeboredom.net>
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using Synapse.UI;
using Synapse.QtClient.Windows;
using Qyoto;
using Synapse.UI.Actions.ExtensionNodes;

namespace Synapse.Addins.PasteBox
{
	public class ActionHandler
	{
		[ActionHandler("Synapse.Addins.PasteBox.Actions.ShowPasteBox")]
		public void ShowPasteBox (object o, EventArgs args)
		{
			QAction action = (QAction)o;
			var dialog = new PasteBoxDialog(action.ParentWidget());
			dialog.Show();
		}
	}
}
