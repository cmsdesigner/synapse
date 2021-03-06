//
// SynapseJSObject.cs: Common JS object available in all QWebViews.
// 
// Copyright (C) 2009 Eric Butler
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
using Qyoto;

namespace Synapse.QtClient
{
	public class SynapseJSObject : QObject
	{
		public SynapseJSObject(QObject parent) : base (parent)
		{
			
		}

		[Q_SLOT]
		public void debug (string text)
		{
			Console.WriteLine(text);
		}
		
		[Q_SLOT]
		public void setClipboard (string text)
		{
			var clipboard = QApplication.Clipboard();
			clipboard.SetText(text);
		}
	}
}
