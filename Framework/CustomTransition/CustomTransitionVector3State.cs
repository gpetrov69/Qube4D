using UnityEngine;
using System.Collections;

public class CustomTransitionVector3State
{
	private Vector3 _stateValues = new Vector3(0f,0f,0f);
	public Vector3 StateValues
	{
		get{return _stateValues;}
		set{_stateValues=value;}
	}
	
	private Vector3 _stateDeltaValues = new Vector3(0f,0f,0f);
	public Vector3 StateDeltaValues
	{
		set{_stateDeltaValues=value;}
		get{return _stateDeltaValues;}
	}
	
	private Vector3 _toStateFinalApproachValues = new Vector3(0.001f,0.001f,0.001f);
	public Vector3 ToStateFinalApproachValues
	{
		get{return _toStateFinalApproachValues;}
		set{_toStateFinalApproachValues = value;}
	}

	private Vector3 _toStateSpeeds = new Vector3(1f,1f,1f);
	public Vector3 ToStateSpeeds
	{
		get{return _toStateSpeeds;}
		set{_toStateSpeeds = value;}
	}

	private Vector3 _toStateStartDelays = new Vector3(0f,0f,0f);
	public Vector3 ToStateStartDelays
	{
		get{return _toStateStartDelays;}
		set{_toStateStartDelays = value;}
	}

	public static CustomTransitionVector3State Clone(CustomTransitionVector3State source)
	{
		CustomTransitionVector3State result = new CustomTransitionVector3State();
		result.StateValues = new Vector3(source.StateValues.x,source.StateValues.y,source.StateValues.z);
		result.StateDeltaValues = new Vector3(source.StateDeltaValues.x,source.StateDeltaValues.y,source.StateDeltaValues.z);
		result.ToStateFinalApproachValues = new Vector3(source.ToStateFinalApproachValues.x,source.ToStateFinalApproachValues.y,source.ToStateFinalApproachValues.z);
		result.ToStateSpeeds = new Vector3(source.ToStateSpeeds.x,source.ToStateSpeeds.y,source.ToStateSpeeds.z);
		result.ToStateStartDelays = new Vector3(source.ToStateStartDelays.x,source.ToStateStartDelays.y,source.ToStateStartDelays.z);

		return result;
	}
}
