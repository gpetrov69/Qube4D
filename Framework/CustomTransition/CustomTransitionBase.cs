using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Qube4d.Framework.Extensions;

namespace Qube4d.Framework.CustomTransition
{
	public class CustomTransitionBase : MonoBehaviour, ICustomTransition
	{
		#region ICustomTransition implementation
		
		public virtual IEnumerator ToggleTransition(bool isTowardsFinalState)
		{
			throw new NotImplementedException("Not implemented in base class");
		}
		
		#endregion

		#region Public properties

		/// <summary>
		/// The state of the transition.
		/// </summary>
		protected TransitionStage _transitionStage = TransitionStage.Initial;
		public TransitionStage TransitionStage
		{
			get{return _transitionStage;}
		}
		
		/// <summary>
		/// The context of the transition.
		/// </summary>
		protected TransitionContext _transitionContext = TransitionContext.Unknown;
		public TransitionContext TransitionContext
		{
			set{_transitionContext = value;}
		}
		
		protected Transform _objectTransform;
		/// <summary>
		/// The transform that has to be manipulated.
		/// </summary>
		public Transform ObjectTransform
		{
			set{
				_objectTransform=value;
				if(_objectTransform==null) return;
				
				if(!_objectTransform.gameObject.HasCollider()) //fallback code in case the object has no collider attached - so it will not be able ot receive raycast
					_objectTransform.gameObject.AddComponent<MeshCollider>();
			}
			get{return _objectTransform;}
		}

		/*public List<CustomTransitionState> TransitionStates
		{
			set
			{
				for(int i=0; i < value.Count; i++)
				{
					if(i==0)
					{
						if(_transitionStates.Count < 1) //list is empty 
							_transitionStates.Add(new CustomTransitionState());
						//state values for initial state should not be allowed to be set
						_transitionStates[i].ToStateFinalApproachValues = value[i].ToStateFinalApproachValues;
						_transitionStates[i].ToStateSpeeds = value[i].ToStateSpeeds;
						_transitionStates[i].ToStateStartDelays = value[i].ToStateStartDelays;
					}
					else 
					{
						if((_transitionStates.Count-1) < i) //the state does not exist in the list
							_transitionStates.Add(value[i]);
						else
							_transitionStates[i] = value[i];
					}
				}

			}
		}

		public CustomTransitionState FinalTransitionState 
		{
			set
			{
				if(_transitionStates.Count > 1)
				{
					_transitionStates[_transitionStates.Count - 1] = value;
				}
				else if(_transitionStates.Count > 0) //only initial state exists
				{
					_transitionStates.Add(value);
				}
				else  //list is empty
				{
					//add empty initial state
					_transitionStates.Add(new CustomTransitionState());
					//now add this as final state
					_transitionStates.Add(value);
				}

				//fix state values from deltas
				if(value.StateValues==null)
				{
					_transitionStates[_transitionStates.Count - 1].StateValues=new float[value.StateDeltaValues.Length];
					for(int i=0; i<value.StateDeltaValues.Length;i++)
					{
						_transitionStates[_transitionStates.Count - 1].StateValues[i]=_transitionStates[_transitionStates.Count - 2].StateValues[i] + value.StateDeltaValues[i];
					}
				}
			}
			get
			{
				return _transitionStates[_transitionStates.Count -1];
			}
		}

		public CustomTransitionState InitialTransitionState
		{
			get
			{
				if(_transitionStates.Count < 1)
				{
					_transitionStates.Add(new CustomTransitionState());
				}
				return _transitionStates[0];
			}
		}*/

		/*
		protected Vector3 _initialStateValues = new Vector3(0f,0f,0f);
		
		protected Vector3 _initialStateFinalApproachValues=new Vector3(0.001f,0.001f,0.001f);
		/// <summary>
		/// Transition final approach X value. It determines the roughness of ending the transition.
		/// </summary>
		public float InitialStateFinalApproachValuesX
		{
			set{
				_initialStateFinalApproachValues.x=value;
			}
		}
		/// <summary>
		/// Transition final approach Y value. It determines the roughness of ending the transition.
		/// </summary>
		public float InitialStateFinalApproachValuesY
		{
			set{
				_initialStateFinalApproachValues.y=value;
			}
		}
		/// <summary>
		/// Transition final approach Z value. It determines the roughness of ending the transition.
		/// </summary>
		public float InitialStateFinalApproachValuesZ
		{
			set{
				_initialStateFinalApproachValues.z=value;
			}
		}
		
		private Vector3 _finalStateDeltaValues = new Vector3(0f,0f,0f);
		/// <summary>
		/// Value (X) of the final state.
		/// </summary>
		public float FinalStateDeltaValuesX
		{
			set
			{
				_finalStateDeltaValues.x=value;
			}
		}
		/// <summary>
		/// Value (Y) of the final state.
		/// </summary>
		public float FinalStateDeltaValuesY
		{
			set
			{
				_finalStateDeltaValues.y=value;
			}
		}
		/// <summary>
		/// Value (Z) of the final state.
		/// </summary>
		public float FinalStateDeltaValuesZ
		{
			set
			{
				_finalStateDeltaValues.z=value;
			}
		}
		
		protected Vector3 _finalStateValues
		{
			get
			{
				return _initialStateValues+_finalStateDeltaValues;
			}
		}
		
		protected Vector3 _finalStateFinalApproachValues=new Vector3(0.001f,0.001f,0.001f);
		/// <summary>
		/// Transition final approach X value. It determines the roughness of ending the transition.
		/// </summary>
		public float FinalStateFinalApproachValuesX
		{
			set{
				_finalStateFinalApproachValues.x=value;
			}
		}
		/// <summary>
		/// Transition final approach Y value. It determines the roughness of ending the transition.
		/// </summary>
		public float FinalStateFinalApproachValuesY
		{
			set{
				_finalStateFinalApproachValues.y=value;
			}
		}
		/// <summary>
		/// Transition final approach Z value. It determines the roughness of ending the transition.
		/// </summary>
		public float FinalStateFinalApproachValuesZ
		{
			set{
				_finalStateFinalApproachValues.z=value;
			}
		}
		
		protected Vector3 _transitionSpeeds=new Vector3(1.0f,1.0f,1.0f);
		/// <summary>
		/// The speed multiplier to apply to the transition. This values is multiplied by Time.deltaTime of the frame rate.
		/// </summary>
		public float TransitionSpeedsX
		{
			set{ 
				_transitionSpeeds.x=value;
			}
		}
		/// <summary>
		/// The speed multiplier to apply to the transition. This values is multiplied by Time.deltaTime of the frame rate.
		/// </summary>
		public float TransitionSpeedsY
		{
			set{ 
				_transitionSpeeds.y=value;
			}
		}
		/// <summary>
		/// The speed multiplier to apply to the transition. This values is multiplied by Time.deltaTime of the frame rate.
		/// </summary>
		public float TransitionSpeedsZ
		{
			set{ 
				_transitionSpeeds.z=value;
			}
		}

		protected Vector3 _transitionForwardStartDelays=new Vector3(0f,0f,0f);
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionForwardStartDelaysX
		{
			set{ 
				_transitionForwardStartDelays.x=value;
			}
		}
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionForwardStartDelaysY
		{
			set{ 
				_transitionForwardStartDelays.y=value;
			}
		}
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionForwardStartDelaysZ
		{
			set{ 
				_transitionForwardStartDelays.z=value;
			}
		}

		protected Vector3 _transitionBackwardStartDelays=new Vector3(0f,0f,0f);
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionBackwardStartDelaysX
		{
			set{ 
				_transitionBackwardStartDelays.x=value;
			}
		}
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionBackwardStartDelaysY
		{
			set{ 
				_transitionBackwardStartDelays.y=value;
			}
		}
		/// <summary>
		/// The start delay (in seconds) before the transition starts.
		/// </summary>
		public float TransitionBackwardStartDelaysZ
		{
			set{ 
				_transitionBackwardStartDelays.z=value;
			}
		}*/
		
		/// <summary>
		/// The transition context:local or global coordinates.
		/// </summary>
		protected TransitionCoordinates _transitionCoordinates = TransitionCoordinates.Global;
		public TransitionCoordinates TransitionCoordinates
		{
			set{_transitionCoordinates = value;}
		}
		
		/// <summary>
		/// For keyboard input, this is the keyboard button that will initiate transition towards the final state.
		/// </summary>
		protected KeyCode _towardsFinalStateKeyboardButton;
		public KeyCode TowardsFinalStateKeyboardButton
		{
			set{
				_towardsFinalStateKeyboardButton=value;
			}
		}
		
		/// <summary>
		/// For keyboard input, this is the keyboard button that will initiate transition towards the initial state.
		/// </summary>
		protected KeyCode _towardsInitialStateKeyboardButton;
		public KeyCode TowardsInitialStateKeyboardButton
		{
			set{
				_towardsInitialStateKeyboardButton=value;
			}
		}
		
		/// <summary>
		/// For touch input to capture and respond to moving jesture we need to define "positive" direction (e.g. towards the final state). Other ("negative")
		/// direction is the one towards the initial state.
		/// </summary>
		protected TouchPositiveDirection _touchPositiveDirection;
		public TouchPositiveDirection TouchPositiveDirection
		{
			set{
				_touchPositiveDirection=value;
			}
		}
		
		/// <summary>
		/// Object to hold a texture that will replace the cursor when mouse is over the "hot spot"
		/// </summary>
		public Texture2D HotSpotCursor{get;set;}
		
		public bool IsTowardsFinalState {get{ return _isTowardsFinalState;}}
		
		/// <summary>
		/// Whether to raise notification events for transition start/stop.
		/// </summary>
		protected bool _sendNotificationsForTransitionEvents = false;
		public bool SendNotificationsForTransitionEvents
		{
			set{_sendNotificationsForTransitionEvents=value;}
		}
		
		/// <summary>
		/// Whether to receive notification events for other transition start/stop.
		/// </summary>
		protected bool _receiveNotificationsForTransitionEvents = false;
		public bool ReceiveNotificationsForTransitionEvents
		{
			set{_receiveNotificationsForTransitionEvents=value;}
		}
		
		#endregion

		#region Protected methods

		protected virtual void Update()
		{
			if(Input.GetKey(KeyCode.Escape)) Application.Quit();
			
			if(Input.GetKey(_towardsFinalStateKeyboardButton)) 
			{
				this.startTransition(true);
			}
			
			if(Input.GetKey(_towardsInitialStateKeyboardButton)) 
			{
				this.startTransition(false);
			}
			
			if(Input.touchCount>0)
			{
				Touch touch0 = Input.GetTouch(0);
				var ray = Camera.main.ScreenPointToRay(touch0.position);
				RaycastHit hit;
				if(Physics.Raycast(ray,out hit))
				{
					Transform transformHit = hit.transform;
					if(transformHit==_objectTransform && touch0.phase==TouchPhase.Moved)
					{
						Vector2 touchDeltaPos = touch0.deltaPosition;
						this.startTransition(isTouchMoveTowardsFinalState(touchDeltaPos));
					}
				}
			}
			else //check if mouse is used
			{
				if(Input.GetMouseButtonDown(0))
				{
					var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
					RaycastHit hit;
					if(Physics.Raycast(ray,out hit))
					{
						Transform transformHit = hit.transform;
						if(transformHit==_objectTransform)
						{
							this.startTransition(!_isTowardsFinalState);
						}
					}
				}
			}
		}

		#endregion

		#region Protected fields
		
		protected bool _isTowardsFinalState=false;

		#endregion

		#region Private methods

		#region Event handlers
		private void OnMouseEnter () {
			Cursor.SetCursor(HotSpotCursor, Vector2.zero, CursorMode.Auto);
		}
		private void OnMouseExit () {
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		}
		private void onTransitionStartedEventHandler(object sender, DataEventArgs ea)
		{
			if((sender as CustomTransitionBase).ObjectTransform==this.ObjectTransform) return;

			//we want to notify parent if child transform has transitioned, so parent also starts transitioning
			//the reverse is handled by Unity - if parent is transitioning - child automatically is transitioning
			//this will be invoked only if _receiveNotificationsForTransitionEvents=true
			var senderTransform = (sender as CustomTransitionBase).ObjectTransform;
			if(senderTransform.IsChildOf(_objectTransform))
			{
				this.startTransition((bool)ea.Data);
				//Debug.Log(String.Format("Parent {0} started transition as called by child {1}",_objectTransform.gameObject.name,senderTransform));  //TODO: remove
			}
		}
		#endregion

		protected virtual void Start()
		{
			if(_receiveNotificationsForTransitionEvents)
				TransitionEventManager.TransitionStarted+=onTransitionStartedEventHandler;
		}
		
		private void OnDisable()
		{
			if(_receiveNotificationsForTransitionEvents)
				TransitionEventManager.TransitionStarted-=onTransitionStartedEventHandler;
		}

		private void startTransition(bool isTowardsFinalState)
		{
			if(_transitionStage==TransitionStage.Transitioning) stopTransition();

			StartCoroutine("ToggleTransition",isTowardsFinalState);
			this.raiseTransitionStarted(isTowardsFinalState);
		}
		
		private void stopTransition()
		{
			StopCoroutine("ToggleTransition");
			this.raiseTransitionStopped();
		}

		private void raiseTransitionStarted(bool isTowardsFinalState)
		{
			if(_sendNotificationsForTransitionEvents) 
			{
				TransitionEventManager.Instance.RaiseTransitionStartedEvent(this,new DataEventArgs(isTowardsFinalState));
			}
		}

		private void raiseTransitionStopped()
		{
			if(_sendNotificationsForTransitionEvents) 
			{
				TransitionEventManager.Instance.RaiseTransitionStoppedEvent(this);
			}
		}

		private bool isTouchMoveTowardsFinalState(Vector2 touchDeltaPos)
		{
			//to determine if the finger movement was meant to final rotation we need to compare
			//delta position of the move with the defined "positive direction"
			if(touchDeltaPos.x>0.0f || touchDeltaPos.y>0.0f) //move up and/or right
			{
				return _touchPositiveDirection==TouchPositiveDirection.UpOrRight;
			}
			else if(touchDeltaPos.x<0.0f || touchDeltaPos.y>0.0f) //move up and/or left
			{
				return _touchPositiveDirection==TouchPositiveDirection.UpOrLeft;
			}
			else if(touchDeltaPos.x<0.0f || touchDeltaPos.y<0.0f) //move down and/or left
			{
				return _touchPositiveDirection==TouchPositiveDirection.DownOrLeft;
			}
			else if(touchDeltaPos.x>0.0f || touchDeltaPos.y<0.0f) //move down and/or right
			{
				return _touchPositiveDirection==TouchPositiveDirection.DownOrRight;
			}
			
			return false;  //no movement
		}

		#endregion
		
	}
}
