using UnityEngine;
using System;
using System.Collections;

namespace Qube4d.Framework
{
	public sealed class TransitionEventManager
	{
		#region Singleton with static constructor
		
		private static readonly TransitionEventManager _instance;
		
		private TransitionEventManager()
		{
			this.Initialize();
		}
		
		static TransitionEventManager ()
		{
			_instance = new TransitionEventManager ();
		}
		
		public static TransitionEventManager Instance {
			get {
				return _instance;
			}
		}
		
		#endregion

		#region Public events

		public delegate void TransitionStartedEvent(object sender, DataEventArgs ea);
		public static event TransitionStartedEvent TransitionStarted;
		
		public delegate void TransitionStoppedEvent(object sender);
		public static event TransitionStoppedEvent TransitionStopped;

		#endregion

		#region Public methods

		public void RaiseTransitionStartedEvent(object sender, DataEventArgs ea)
		{
			if(TransitionStarted!=null)
				{
					TransitionStarted(sender,ea);
				}
		}

		public void RaiseTransitionStoppedEvent(object sender)
		{
			if(TransitionStopped!=null)
			{
				TransitionStopped(sender);
			}
		}

		#endregion

		#region Private methods
		
		private void Initialize()
		{
		}
		
		#endregion
	}
}