using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour 
{
	private Texture2D _handCursor;
	private Texture2D _pullDownCursor;
	private Texture2D _kickCursor;

	void Awake()
	{
		//load resources
		_handCursor = Resources.Load("handCursor") as Texture2D;
		_pullDownCursor = Resources.Load("handCursor") as Texture2D;  //TODO: find appropriate cursors
		_kickCursor = Resources.Load("handCursor") as Texture2D;  //TODO: find appropriate cursors


		//add controller scripts to objects
		foreach(Transform child in transform)
		{
			if(child.gameObject.name.Contains(ObjectTypeNames.EmergencyExitLeft)
			   ||child.gameObject.name.Contains(ObjectTypeNames.EmergencyExitRight))
			{
				var ctrl = child.gameObject.AddComponent<EmergencyDoorController>();
				ctrl.HandCursor = _handCursor;
				ctrl.PullDownCursor = _pullDownCursor;
				ctrl.KickCursor = _kickCursor;
			}
			if(child.gameObject.name.Contains(ObjectTypeNames.MediumBin))
			{
				child.gameObject.AddComponent<BinController>().HotSpotCursor = _handCursor;
			}
			if(child.gameObject.name.Contains(ObjectTypeNames.SeatsType01Left))
			{
				child.gameObject.AddComponent<SeatsController>().HotSpotCursor = _handCursor;
			}

			//main gear
			if(child.gameObject.name.Contains(ObjectTypeNames.LeftMainGearAssembly))
			{
				child.gameObject.AddComponent<MainLandingGearController>().HotSpotCursor = _handCursor;
			}
			if(child.gameObject.name.Contains(ObjectTypeNames.RightMainGearAssembly))
			{
				child.gameObject.AddComponent<MainLandingGearController>().HotSpotCursor = _handCursor;
			}
			if(child.gameObject.name.Contains(ObjectTypeNames.FrontGearAssembly))
			{
				child.gameObject.AddComponent<FrontLandingGearController>().HotSpotCursor = _handCursor;
			}
		}
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.Escape)) Application.Quit();
	}
}
