using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using Qube4d.Framework.CustomTransition;
using Qube4d.Framework.Extensions;

public class EmergencyDoorController : MonoBehaviour 
{
	[HideInInspector]
	public Texture2D HandCursor;
	[HideInInspector]
	public Texture2D PullDownCursor;
	[HideInInspector]
	public Texture2D KickCursor;

	private CustomRotator _handleCoverRotator;
	private CustomTranslator _handleTranslator;
	private CustomRotator _doorRotator;

	void Awake()
	{
		var allChildren = transform.Descendants();

		foreach(var child in allChildren)
		{
			//handle cover behavior
			if(child.gameObject.name == ObjectTypeNames.EmergencyExitHandleCover)
			{
				_handleCoverRotator = child.gameObject.AddComponent<CustomRotator>().Create(child, TransitionCoordinates.Local);

				CustomTransitionVector3State initialState = _handleCoverRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				initialState.ToStateSpeeds=new Vector3(0f,6f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,-95f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(0f,1f,0f);
				finalState.ToStateSpeeds=new Vector3(0f,6f,0f);
				
				_handleCoverRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only

				/*_handleCoverRotator.FinalStateDeltaValuesY=-95f;
				_handleCoverRotator.FinalStateFinalApproachValuesY = 1f;
				_handleCoverRotator.InitialStateFinalApproachValuesY = 1f;
				_handleCoverRotator.TransitionSpeedsY=6f;*/

				_handleCoverRotator.TowardsFinalStateKeyboardButton=KeyCode.Alpha3;
				_handleCoverRotator.TowardsInitialStateKeyboardButton=KeyCode.Alpha4;
				_handleCoverRotator.HotSpotCursor=PullDownCursor;
			}

			//handle behavior
			if(child.gameObject.name == ObjectTypeNames.EmergencyExitHandle)
			{
				_handleTranslator = child.gameObject.AddComponent<CustomTranslator>().Create(child, TransitionCoordinates.Local);

				CustomTransitionVector3State initialState = _handleTranslator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0.005f,0f,0f);

				CustomTransitionVector3State stateInterm = new CustomTransitionVector3State();
				stateInterm.StateDeltaValues=new Vector3(0.01f,0f,0f);
				stateInterm.ToStateFinalApproachValues=new Vector3(0.005f,0f,0.005f);
				_handleTranslator.TransitionStates.Add(stateInterm);
				
				CustomTransitionVector3State stateFinal = new CustomTransitionVector3State();
				stateFinal.StateDeltaValues=new Vector3(0f,0f,-0.02f);
				stateFinal.ToStateFinalApproachValues=new Vector3(0f,0f,0.005f);
				_handleTranslator.TransitionStates.Add(stateFinal);
				

				/*_handleTranslator.FinalStateDeltaValuesX=0.01f;
				_handleTranslator.FinalStateFinalApproachValuesX = 0.005f;
				_handleTranslator.InitialStateFinalApproachValuesX = 0.005f;
				_handleTranslator.TransitionSpeedsX=3f;

				_handleTranslator.FinalStateDeltaValuesZ=-0.02f;
				_handleTranslator.FinalStateFinalApproachValuesZ = 0.005f;
				_handleTranslator.InitialStateFinalApproachValuesZ = 0.005f;
				_handleTranslator.TransitionSpeedsX=5f;*/

				_handleTranslator.TowardsFinalStateKeyboardButton=KeyCode.Alpha5;
				_handleTranslator.TowardsInitialStateKeyboardButton=KeyCode.Alpha6;
				_handleTranslator.HotSpotCursor=PullDownCursor;

				_handleTranslator.enabled = false;
			}

			//door behavior
			if(child.gameObject.name == ObjectTypeNames.EmergencyExitDoor)
			{
				_doorRotator = child.gameObject.AddComponent<CustomRotator>().Create(child, TransitionCoordinates.Local);

				CustomTransitionVector3State initialState = _doorRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,5f,0f);
				initialState.ToStateSpeeds=new Vector3(0f,5f,0f);
				
				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,80f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(0f,5f,0f);
				finalState.ToStateSpeeds=new Vector3(0f,5f,0f);
				
				_doorRotator.TransitionStates.Add(finalState);

				/*_doorRotator.FinalStateDeltaValuesY=80f;
				_doorRotator.FinalStateFinalApproachValuesY = 5f;
				_doorRotator.InitialStateFinalApproachValuesY = 5f;
				_doorRotator.TransitionSpeedsY=5f;*/
				
				_doorRotator.TowardsFinalStateKeyboardButton=KeyCode.Alpha7;
				_doorRotator.TowardsInitialStateKeyboardButton=KeyCode.Alpha8;
				_doorRotator.HotSpotCursor=PullDownCursor;

				_doorRotator.enabled = false;
			}
		}
	}

	void Update()
	{
		#region Controller states interactions

		if(_handleCoverRotator.TransitionStage==TransitionStage.Final)
		{
			_handleTranslator.enabled = true; //cover is open, access to the handle granted
		}
		else
		{
			_handleTranslator.enabled = false; //cover is closed, access to the handle denied
		}
		
		if(_handleTranslator.TransitionStage==TransitionStage.Final)
		{
			_doorRotator.enabled = true; //handle is pulled, access to the door granted
			_handleCoverRotator.enabled = false; //handle is pulled, cannot close the cover
		}
		else if(_handleTranslator.TransitionStage==TransitionStage.Initial)
		{
			_doorRotator.enabled = false; //handle is not pulled, access to the door denied
			_handleCoverRotator.enabled = true; //handle is not pulled, cover can be closed
		}
		else  //transitioning
		{
			_doorRotator.enabled = false;
			_handleCoverRotator.enabled = false;
		}
		
		#endregion
	}
}
