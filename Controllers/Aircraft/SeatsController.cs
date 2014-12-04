using UnityEngine;
using System.Collections;

using Qube4d.Framework.CustomTransition;
using Qube4d.Framework.Extensions;

public class SeatsController : MonoBehaviour 
{
	[HideInInspector]
	public Texture2D HotSpotCursor;

	void Awake()
	{
		#region Add behaviours
		var allChildren = transform.Descendants();
		
		foreach(var child in allChildren)
		{
			
			var customRotator = child.gameObject.AddComponent<CustomRotator>().Create(child, TransitionCoordinates.Local);
			customRotator.TowardsFinalStateKeyboardButton=KeyCode.Alpha1;
			customRotator.TowardsInitialStateKeyboardButton=KeyCode.Alpha2;
			customRotator.HotSpotCursor=HotSpotCursor;
			
			if(child.gameObject.name.StartsWith(ObjectTypeNames.SeatsType01ArmRest))
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				initialState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-80f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				finalState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only

				/*customRotator.FinalStateDeltaValuesX=-80f;
				customRotator.FinalStateFinalApproachValuesX = 1f;
				customRotator.InitialStateFinalApproachValuesX = 1f;
				customRotator.TransitionSpeedsX=2f;*/
			}
			else if(child.gameObject.name.StartsWith(ObjectTypeNames.SeatsType01MetalHinge))
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				initialState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-15f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(1f,0f,0f);
				finalState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only

				/*customRotator.FinalStateDeltaValuesX=-15f;
				customRotator.InitialStateFinalApproachValuesX=1f;
				customRotator.FinalStateFinalApproachValuesX=1f;
				customRotator.TransitionSpeedsX=2f;*/
				customRotator.ReceiveNotificationsForTransitionEvents=true;
			}
			else if(child.gameObject.name.StartsWith(ObjectTypeNames.SeatsType01TrayTable))
			{
				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				initialState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(-70f,0f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(2f,0f,0f);
				finalState.ToStateSpeeds=new Vector3(2f,0f,0f);
				
				customRotator.TransitionStates.Add(finalState); 

				/*customRotator.FinalStateDeltaValuesX=-70f;
				customRotator.TransitionSpeedsX=2f;
				customRotator.InitialStateFinalApproachValuesX=2f;
				customRotator.FinalStateFinalApproachValuesX=2f;*/
				customRotator.SendNotificationsForTransitionEvents = true;
			}
		}

		#endregion
	}

	void Update()
	{

	}
}
