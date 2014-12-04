using UnityEngine;
using System.Collections;

using Qube4d.Framework.CustomTransition;
using Qube4d.Framework.Extensions;

public class BinController : MonoBehaviour 
{
	[HideInInspector]
	public Texture2D HotSpotCursor;

	void Awake()
	{
		var allChildren = transform.Descendants();

		foreach(var child in allChildren)
		{
			if(child.name==ObjectTypeNames.MediumBinDoor)
			{
				var customRotator = child.gameObject.AddComponent<CustomRotator>().Create(child,TransitionCoordinates.Local);

				CustomTransitionVector3State initialState = customRotator.InitialTransitionState;
				initialState.ToStateFinalApproachValues=new Vector3(0f,2f,0f);
				initialState.ToStateSpeeds=new Vector3(0f,3f,0f);

				CustomTransitionVector3State finalState = new CustomTransitionVector3State();
				finalState.StateDeltaValues=new Vector3(0f,90f,0f);
				finalState.ToStateFinalApproachValues=new Vector3(0f,2f,0f);
				finalState.ToStateSpeeds=new Vector3(0f,3f,0f);

				customRotator.TransitionStates.Add(finalState); //initial state is auto added, so we add additional states only


				/*customRotator.FinalStateDeltaValuesY = 90f;
				customRotator.FinalStateFinalApproachValuesY = 2f;
				customRotator.InitialStateFinalApproachValuesY = 2f;
				customRotator.TransitionSpeedsY = 3f;
*/
				customRotator.TowardsFinalStateKeyboardButton = KeyCode.O;
				customRotator.TowardsInitialStateKeyboardButton = KeyCode.C;
				customRotator.HotSpotCursor=HotSpotCursor;
				//TODO: define touch positive direction for touch screen
			}
		}
	}
}
