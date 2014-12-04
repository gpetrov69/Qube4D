using UnityEngine;
using System.Collections;

using Qube4d.Framework.CustomTransition;
using Qube4d.Framework.Extensions;

public class MainLandingGearController : MonoBehaviour 
{
	[HideInInspector]
	public Texture2D HotSpotCursor;

	void Awake()
	{
		var allChildren = transform.Descendants();

		foreach(var child in allChildren)
		{
			var customRotator = child.gameObject.AddComponent<CustomRotator>().Create(child,TransitionCoordinates.Local);
			customRotator.TowardsFinalStateKeyboardButton = KeyCode.LeftBracket;
			customRotator.TowardsInitialStateKeyboardButton = KeyCode.RightBracket;

			#region Left main landing gear
			if(child.name==ObjectTypeNames.LeftMainGearMainHinge)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(2f,0f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(60f,0f,0f);

				finalState.ToStateStartDelays=new Vector3(2f,0f,0f);
								
				customRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only

				//customRotator.FinalStateDeltaValuesX = 60f;
			}
			if(child.name==ObjectTypeNames.LeftMainGearStrutConnector)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				initialState.ToStateStartDelays=new Vector3(0f,2f,0f);
								
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-165f,0f);

				finalState.ToStateStartDelays=new Vector3(0f,2f,0f);
								
				customRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only

				/*customRotator.FinalStateDeltaValuesY = -165f;
				customRotator.InitialStateFinalApproachValuesY = 1f;*/
			}
			if(child.name==ObjectTypeNames.LeftMainGearShock)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(0f,2f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,28f,0f);

				finalState.ToStateStartDelays=new Vector3(0f,2f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = 28f;
			}
			if(child.name==ObjectTypeNames.LeftMainGearSmallOuterDoor)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				initialState.ToStateSpeeds=new Vector3(2f,0f,0f);

				CustomTransitionVector3State intermState = new CustomTransitionVector3State();
				intermState.StateDeltaValues=new Vector3(90f,0f,0f);
				intermState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				intermState.ToStateSpeeds=new Vector3(2f,0f,0f);

				customRotator.TransitionStates.Add(intermState);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-90f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				finalState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = -90f;
				customRotator.FinalStateFinalApproachValuesX = 1f;
				customRotator.InitialStateFinalApproachValuesX = 1f;*/
			}
			if(child.name==ObjectTypeNames.LeftMainGearSmallWheelDoorHinge)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(0f,2f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-65f,0f);

				finalState.ToStateStartDelays=new Vector3(0f,2f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = -65f;
			}
			if(child.name==ObjectTypeNames.LeftMainGearSmallWheelDoorCntr)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(0f,2f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,30f,0f);

				finalState.ToStateStartDelays=new Vector3(0f,2f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = 30f;
			}
			#endregion

			#region Right main landing gear
			if(child.name==ObjectTypeNames.RightMainGearMainHinge)
			{
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-60f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesX = -60f;
			}
			if(child.name==ObjectTypeNames.RightMainGearStrutConnector)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,165f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesY = 165f;
				customRotator.InitialStateFinalApproachValuesY = 1f;*/
			}
			if(child.name==ObjectTypeNames.RightMainGearShock)
			{
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-28f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = -28f;
			}
			if(child.name==ObjectTypeNames.RightMainGearSmallOuterDoor)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-90f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = -90f;
				customRotator.FinalStateFinalApproachValuesX = 1f;
				customRotator.InitialStateFinalApproachValuesX = 1f;*/
			}
			if(child.name==ObjectTypeNames.RightMainGearSmallWheelDoorHinge)
			{
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,65f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = 65f;
			}
			if(child.name==ObjectTypeNames.RightMainGearSmallWheelDoorCntr)
			{
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-30f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				//customRotator.FinalStateDeltaValuesY = -30f;
			}
			#endregion
		}
	}
}
