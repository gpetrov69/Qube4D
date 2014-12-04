using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

using Qube4d.Framework.Extensions;

namespace Qube4d.Framework.CustomTransition
{
/// <summary>
/// Base class for moving transitions (translation/rotation)
/// </summary>
	public class CustomMoverBase : CustomTransitionBase
	{
		#region Public properties

		protected List<CustomTransitionVector3State> _transitionStates = new List<CustomTransitionVector3State>();
		public List<CustomTransitionVector3State> TransitionStates
		{
			get{return _transitionStates;}
			set{_transitionStates=value;this.calculateStateValues(_transitionStates);}
		}

		public CustomTransitionVector3State FinalTransitionState
		{
			get{return TransitionStates[TransitionStates.Count-1];}
		}

		public CustomTransitionVector3State InitialTransitionState
		{
			get{return TransitionStates[0];}
		}

		#endregion

		#region Public methods

		public override IEnumerator ToggleTransition(bool isTowardsFinalState)
		{
			if(_transitionCoordinates == TransitionCoordinates.Unknown) yield return null;
			
			if(isTowardsFinalState)
			{
				_isTowardsFinalState=true;
				_transitionStage=TransitionStage.Transitioning;

				#region transition
				for(int i = 1; i < _transitionStates.Count; i++) //skip the initial state
				{
					Vector3 forwardStartDelays = _transitionStates[i].ToStateStartDelays;
					while(true)
					{
						Vector3 currentValues = _currentState.StateValues;
						bool targetStateReached = this.applyTransitionStep(ref currentValues
						                                                , _transitionStates[i].StateValues
						                                              	, ref forwardStartDelays
						                                                , _transitionStates[i].ToStateFinalApproachValues
						                                                , _transitionStates[i].ToStateSpeeds);
						_currentState.StateValues=currentValues;

						if(targetStateReached) break;  //target state reached - exit loop
						
						yield return null;
					}
					yield return null;
				}
				#endregion
				
				#region fix final state
				Vector3 finalValues = this.FinalTransitionState.StateValues;

				switch(_transitionContext)
				{
				case TransitionContext.Rotation:
					switch(_transitionCoordinates)
					{
					case TransitionCoordinates.Global:

						_objectTransform.rotation=Quaternion.Euler(finalValues);
						break;
					case TransitionCoordinates.Local:
						_objectTransform.localRotation=Quaternion.Euler(finalValues);
						break;
					}
					break;
				case TransitionContext.Translation:
					switch(_transitionCoordinates)
					{
					case TransitionCoordinates.Global:
						_objectTransform.position=finalValues;
						break;
					case TransitionCoordinates.Local:
						_objectTransform.localPosition=finalValues;
						break;
					}
					break;
				}
				#endregion
				
				_transitionStage=TransitionStage.Final;
				_currentState = CustomTransitionVector3State.Clone(this.FinalTransitionState);  //reset current state
				StopCoroutine("ToggleTransition");
				Debug.Log("corotine stoped towards final"); //TODO: remove
			}
			else  //towards initial state
			{
				_isTowardsFinalState=false;
				_transitionStage=TransitionStage.Transitioning;

				#region transition
				for(int i = (_transitionStates.Count-2); i >= 0; i--) //skip final state
				{
					Vector3 backwardStartDelays = _transitionStates[i].ToStateStartDelays;
					while(true)
					{//TODO: refactor
						Vector3 currentValues = _currentState.StateValues;
						bool targetStateReached = this.applyTransitionStep(ref currentValues
						                                                   , _transitionStates[i].StateValues
						                                                   , ref backwardStartDelays
						                                                   , _transitionStates[i].ToStateFinalApproachValues
						                                                   , _transitionStates[i].ToStateSpeeds);

						_currentState.StateValues=currentValues;
						if(targetStateReached) break;  //target state reached - exit loop
						
						yield return null;
					}
					yield return null;
				}
				#endregion
				
				#region fix final state
				Vector3 initialValues = this.InitialTransitionState.StateValues;

				switch(_transitionContext)
				{
				case TransitionContext.Rotation:
					switch(_transitionCoordinates)
					{
					case TransitionCoordinates.Global:
						_objectTransform.rotation=Quaternion.Euler(initialValues);
						break;
					case TransitionCoordinates.Local:
						_objectTransform.localRotation=Quaternion.Euler(initialValues);
						break;
					}
					break;
				case TransitionContext.Translation:
					switch(_transitionCoordinates)
					{
					case TransitionCoordinates.Global:
						_objectTransform.position=initialValues;
						break;
					case TransitionCoordinates.Local:
						_objectTransform.localPosition=initialValues;
						break;
					}
					break;
				}
				#endregion
				
				_transitionStage=TransitionStage.Initial;
				_currentState = CustomTransitionVector3State.Clone(this.InitialTransitionState);  //reset current state
				StopCoroutine("ToggleTransition");
				Debug.Log("corotine stoped towards initial"); //TODO: remove
			}
		}

		#endregion

		#region Protected methods

		protected virtual void Init(Transform objectTransform, TransitionCoordinates transitionCoordinates, TransitionContext transitionContext)
		{
			if(_objectTransform==null) this.ObjectTransform=objectTransform;
			_transitionCoordinates = transitionCoordinates;
			_transitionContext = transitionContext;
			_transitionStates.Add(new CustomTransitionVector3State()); //initialize initial state

			//set initial values
			switch(_transitionCoordinates)
			{
			case TransitionCoordinates.Unknown:
				throw new Exception("Transition coordinates not set");
			case TransitionCoordinates.Global:
				switch(_transitionContext)
				{
					case TransitionContext.Translation:
					_transitionStates[0].StateValues = new Vector3(_objectTransform.position.x,_objectTransform.position.y,_objectTransform.position.z);
					//TODO: _initialStateValues = new Vector3(_objectTransform.position.x,_objectTransform.position.y,_objectTransform.position.z);
						break;
					case TransitionContext.Rotation:
					_transitionStates[0].StateValues = new Vector3(_objectTransform.rotation.x,_objectTransform.rotation.y,_objectTransform.rotation.z);
						//TODO: _initialStateValues = new Vector3(_objectTransform.rotation.x,_objectTransform.rotation.y,_objectTransform.rotation.z);
						break;
				}
				break;
			case TransitionCoordinates.Local:
				switch(_transitionContext)
				{
				case TransitionContext.Translation:
					_transitionStates[0].StateValues = new Vector3(_objectTransform.localPosition.x,_objectTransform.localPosition.y,_objectTransform.localPosition.z);
					//TODO: _initialStateValues = new Vector3(_objectTransform.localPosition.x,_objectTransform.localPosition.y,_objectTransform.localPosition.z);
					break;
				case TransitionContext.Rotation:
					_transitionStates[0].StateValues = new Vector3(_objectTransform.localEulerAngles.x,_objectTransform.localEulerAngles.y,_objectTransform.localEulerAngles.z);
					//TODO: _initialStateValues = new Vector3(_objectTransform.localEulerAngles.x,_objectTransform.localEulerAngles.y,_objectTransform.localEulerAngles.z);
					break;
				}
				break;
			}
			
			_currentState = CustomTransitionVector3State.Clone(this.InitialTransitionState);
		}

		#endregion

		#region Private methods

		private bool applyTransitionStep(ref Vector3 currentState, Vector3 targetState, ref Vector3 startDelays, Vector3 finalApproachValues, Vector3 speeds)
		{
			float newXValue=targetState.x;
			float newYValue=targetState.y;
			float newZValue=targetState.z;
			bool xTargetValueReached = false;
			bool yTargetValueReached = false;
			bool zTargetValueReached = false;

			if(startDelays.x<=Time.deltaTime)
			{ //start transition
				xTargetValueReached = _transitionContext==TransitionContext.Rotation
										? currentState.x.ApproxEquals(targetState.x,finalApproachValues.x,false)
										: currentState.x.ApproxEquals(targetState.x,finalApproachValues.x);
				if(!xTargetValueReached)
				{
					newXValue = Mathf.Lerp(currentState.x,targetState.x,Time.deltaTime*speeds.x);
				}
			}
			else //delay transition
			{
				startDelays.x-=Time.deltaTime;
				newXValue = currentState.x;
			}
			
			if(startDelays.y<=Time.deltaTime)
			{ //start transition
				yTargetValueReached = _transitionContext==TransitionContext.Rotation
										? currentState.y.ApproxEquals(targetState.y,finalApproachValues.y,false)
										: currentState.y.ApproxEquals(targetState.y,finalApproachValues.y);
				if(!yTargetValueReached)
				{
					newYValue = Mathf.Lerp(currentState.y,targetState.y,Time.deltaTime*speeds.y);
				}
			}
			else //delay transition
			{
				startDelays.y-=Time.deltaTime;
				newYValue = currentState.y;
			}

			if(startDelays.z<=Time.deltaTime)
			{ //start transition
				zTargetValueReached = _transitionContext==TransitionContext.Rotation
										? currentState.z.ApproxEquals(targetState.z,finalApproachValues.z,false)
										: currentState.z.ApproxEquals(targetState.z,finalApproachValues.z);
				if(!zTargetValueReached)
				{
					newZValue = Mathf.Lerp(currentState.z,targetState.z,Time.deltaTime*speeds.z);
				}
			}
			else //delay transition
			{
				startDelays.z-=Time.deltaTime;
				newZValue = currentState.z;
			}
			
			switch(_transitionCoordinates)
			{
			case TransitionCoordinates.Global:
				switch (_transitionContext)
				{
				case TransitionContext.Rotation:
					_objectTransform.rotation=Quaternion.Euler(newXValue,newYValue,newZValue);
					break;
				case TransitionContext.Translation:
					_objectTransform.position=new Vector3(newXValue,newYValue,newZValue);
					break;
				}
				break;
			case TransitionCoordinates.Local:
				switch (_transitionContext)
				{
				case TransitionContext.Rotation:
					_objectTransform.localRotation=Quaternion.Euler(newXValue,newYValue,newZValue);
					break;
				case TransitionContext.Translation:
					_objectTransform.localPosition=new Vector3(newXValue,newYValue,newZValue);
					break;
				}
				break;
			}

			currentState.x=newXValue;
			currentState.y=newYValue;
			currentState.z=newZValue;

			return (xTargetValueReached && yTargetValueReached && zTargetValueReached);
		
		}

		private void calculateStateValues(List<CustomTransitionVector3State> states)
		{//TODO: refactor - this is also used in custom scaler
			if(states==null || states.Count < 1) return;  //TODO: or throw error???
			
			if(states.Count == 1)  //only initial state
			{
			}
			else //2 or more states
			{
				for (int i = 1; i < states.Count; i++)
				{
					states[i].StateValues = states[i-1].StateValues + states[i].StateDeltaValues;
				}
			}
		}

		protected override void Start()
		{
			base.Start();
			this.calculateStateValues(_transitionStates);
		}

		#endregion

		private CustomTransitionVector3State _currentState;
	}
}