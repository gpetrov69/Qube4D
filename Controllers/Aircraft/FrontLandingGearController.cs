using UnityEngine;
using System.Collections;

using Qube4d.Framework.CustomTransition;
using Qube4d.Framework.Extensions;

public class FrontLandingGearController : MonoBehaviour {

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

			if(child.name==ObjectTypeNames.FrontGearHydraulicCyllinder)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(1.8f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-30f,0f,0f);

				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = -30f;
				customRotator.TransitionBackwardStartDelaysX = 1.8f;*/
			}
			if(child.name==ObjectTypeNames.FrontGearSupport)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(1.8f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(55f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = 55f;
				customRotator.TransitionBackwardStartDelaysX = 1.8f;*/
			}
			if(child.name==ObjectTypeNames.FrontGear)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(1.8f,0f,0f);
				initialState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-160f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = -160f;
				customRotator.TransitionBackwardStartDelaysX = 1.8f;
				customRotator.InitialStateFinalApproachValuesX = 2f;
				customRotator.FinalStateFinalApproachValuesX = 2f;*/
			}
			if(child.name==ObjectTypeNames.FrontGearRods)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateStartDelays=new Vector3(1.8f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(95f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesX = 95f;
				customRotator.TransitionBackwardStartDelaysX = 1.8f;*/
			}
			if(child.name==ObjectTypeNames.FrontGearLeftDoor)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-90f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				finalState.ToStateStartDelays=new Vector3(0f,1.8f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesY = -90f;
				customRotator.TransitionForwardStartDelaysY = 1.8f;
				customRotator.FinalStateFinalApproachValuesY = 1f;
				customRotator.InitialStateFinalApproachValuesY = 1f;*/
			}
			if(child.name==ObjectTypeNames.FrontGearRightDoor)
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,90f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				finalState.ToStateStartDelays=new Vector3(0f,1.8f,0f);
				
				customRotator.TransitionStates.Add(finalState);

				/*customRotator.FinalStateDeltaValuesY = 90f;
				customRotator.TransitionForwardStartDelaysY = 1.8f;
				customRotator.FinalStateFinalApproachValuesY = 1f;
				customRotator.InitialStateFinalApproachValuesY = 1f;*/
			}

		}
	}
}

