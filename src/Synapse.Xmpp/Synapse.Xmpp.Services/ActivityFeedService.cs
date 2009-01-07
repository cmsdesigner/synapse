//
// ActivityFeedService.cs
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
using System.Collections.Generic;
using System.Text;
using Synapse.Core;
using Synapse.Xmpp;
using Synapse.ServiceStack;
using Synapse.Services;
using jabber;
using Mono.Addins;

namespace Synapse.Xmpp.Services
{
	public class ActivityFeedService : IService, IRequiredService, IInitializeService
	{
		public delegate void ActivityFeedItemEventHandler (IActivityFeedItem item);

		List<IShoutHandler> m_ShoutHandlers = new List<IShoutHandler>();
		Queue<IActivityFeedItem> m_Queue = new Queue<IActivityFeedItem>();
		
		public event ActivityFeedItemEventHandler NewItem;
		
		public void Initialize ()
		{
			AddTemplate("synapse", "{0}", "{0}");
			AddTemplate("presence", "is now {0}", "are now {0}");
			AddTemplate("music", "is listening to", "are listening to");
			AddTemplate("microblog", "shouts", "shout");
			AddTemplate("mood", "is feeling {0}", "are feeling {0}");
			
			Application.Client.Started +=  delegate {
				PostItem(null, null, "synapse", "Welcome to Synapse!", null);
			};

			var nodes = AddinManager.GetExtensionNodes("/Synapse/Xmpp/ActivityFeed/ShoutHandlers");
			foreach (var node in nodes) {
				IShoutHandler handler = (IShoutHandler) ((TypeExtensionNode)node).CreateInstance();
				m_ShoutHandlers.Add(handler);
			}
		}

		public void Shout (string message)
		{
			var accountService = ServiceManager.Get<AccountService>();
			foreach (var account in accountService.Accounts) {
				account.GetFeature<Microblogging>().Post(message);
			}

			foreach (var handler in m_ShoutHandlers) {
				handler.Shout(message);
			}
		}

		Dictionary<string, ActivityFeedItemTemplate> m_Templates = new Dictionary<string, ActivityFeedItemTemplate>();
		
		public IDictionary<string, ActivityFeedItemTemplate> Templates {
			get {
				return new ReadOnlyDictionary<string, ActivityFeedItemTemplate>(m_Templates);
			}
		}

		public void AddTemplate (string name, string singularText, string pluralText)
		{
			AddTemplate(name, singularText, pluralText, false, null);
		}
		
		public void AddTemplate (string name, string singularText, string pluralText, bool desktopNotify, NotificationAction[] actions)
		{
			m_Templates.Add(name, new ActivityFeedItemTemplate(name, singularText, pluralText, desktopNotify, actions));
		}
		
		public void PostItem (Account account, JID from, string type, string actionItem, string content)
		{
			PostItem(account, from, type, actionItem, content, null);
		}
		
		public void PostItem (Account account, JID from, string type, string actionItem, string content, string contentUrl)
		{
			PostItem(new XmppActivityFeedItem(account, from, type, actionItem, content, contentUrl));
		}

		public void PostItem (IActivityFeedItem item)
		{
			if (NewItem == null) {
				lock (m_Queue)
					m_Queue.Enqueue(item);
			} else {
				NewItem(item);
			}
			
			var template = m_Templates[item.Type];
			if (template.DesktopNotify) {
				var text = new StringBuilder();
				text.Append(item.FromName);
				text.Append(" ");
				text.AppendFormat(template.SingularText, item.ActionItem);
				
				var n = ServiceManager.Get<NotificationService>();
				if (String.IsNullOrEmpty(item.Content)) {
					text.Append(".");
					n.Notify(text.ToString(), String.Empty, String.Empty, item, template.Actions);
				} else {
					text.Append(":");
					n.Notify(text.ToString(), item.Content, String.Empty, item, template.Actions);
				}
			}
		}		
			
		public void FireQueued () 
		{
			if (NewItem == null) {
				throw new InvalidOperationException("No event handler for NewItem");
			}
			lock (m_Queue) {
				while (m_Queue.Count > 0)
					NewItem(m_Queue.Dequeue());
			}
		}

		public string ServiceName {
			get { return "ActivityFeedService"; }
		}
	}

	public class ActivityFeedItemTemplate
	{
		string m_Name;
		string m_SingularText;
		string m_PlularText;
		bool   m_DesktopNotify;
		NotificationAction[] m_Actions;

		public ActivityFeedItemTemplate (string name, string singularText, string pluarText, bool desktopNotify, 
		                                 NotificationAction[] actions)
		{
			m_Name = name;
			m_SingularText = singularText;
			m_PlularText = pluarText;
			m_DesktopNotify = desktopNotify;
			m_Actions = actions;
		}

		public string Name {
			get {
				return m_Name;
			}
		}

		public string SingularText {
			get {
				return m_SingularText;
			}
		}
		
		public string PluralText {
			get {
				return m_PlularText;
			}
		}
		
		public bool DesktopNotify {
			get {
				return m_DesktopNotify;
			}
		}
		
		public NotificationAction[] Actions {
			get {
				return m_Actions;
			}
		}
	}
	
	public class XmppActivityFeedItem : IActivityFeedItem
	{
		Account  m_Account;
		JID 	 m_From;
		string   m_Type;
		string   m_ActionItem;
		string   m_Content;
		Uri      m_ContentUrl;
		
		public XmppActivityFeedItem (Account account, JID from, string type, string actionItem, string content)
			: this (account, from, type, actionItem, content, null)
		{
		}
		
		public XmppActivityFeedItem (Account account, JID from, string type, string actionItem, string content, string contentUrl)
		{
			if (type == null)
				throw new ArgumentNullException("type");
			
			m_Account    = account;
			m_From       = from;
			m_Type       = type;
			m_ActionItem = Util.EscapeHtml(actionItem);
			m_Content    = Util.EscapeHtml(content);

			if (!String.IsNullOrEmpty(contentUrl)) {
				try {
					m_ContentUrl = new Uri(contentUrl);
					// Anything else would be scary.
					if (m_ContentUrl.Scheme != "http" && m_ContentUrl.Scheme != "https")
						m_ContentUrl = null;
				} catch {}
			}
		}

		public Account Account {
			get {
				return m_Account;
			}
		}
		
		public string FromUrl {
			get {
				return null;
			}
		}

		public string FromJid {
			get {
				return (m_From == null) ? null : m_From.ToString();
			}
		}

		public string FromName {
			get {
				return (m_From == null) ? null : m_Account.GetDisplayName(m_From);
			}
		}

		public string AvatarUrl {
			get {
				string avatarHash = (m_From != null) ? AvatarManager.GetAvatarHash(m_From) : "octy";
				return "avatar:/" + avatarHash;
			}
		}

		public string Type {
			get {
				return m_Type;
			}
		}

		public string ActionItem {
			get {
				return m_ActionItem;
			}
		}

		public string Content {
			get {
				return m_Content;
			}
		}

		public Uri ContentUrl {
			get {
				return m_ContentUrl;
			}
		}

		public void TriggerAction (string actionName)
		{
			var template = ServiceManager.Get<ActivityFeedService>().Templates[m_Type];
			foreach (var action in template.Actions) {
				if (action.Name == actionName) {
					action.Callback(this, EventArgs.Empty);
					return;
				}
			}
			throw new Exception("Action not found: " + actionName);
		}
	}

	public interface IActivityFeedItem
	{
		string FromName {
			get;
		}

		string FromUrl {
			get;
		}

		string AvatarUrl {
			get;
		}

		string Type {
			get;
		}

		string ActionItem {
			get;
		}

		string Content {
			get;
		}

		Uri ContentUrl {
			get;
		}

		void TriggerAction (string actionName);
	}
	
	
	public interface IShoutHandler
	{
		void Shout (string message);
	}
}