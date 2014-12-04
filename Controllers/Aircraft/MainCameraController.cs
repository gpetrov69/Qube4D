using UnityEngine;
using System.Collections;

public class MainCameraController : MonoBehaviour {

	/*private float xMin=-0.7f;
	private float xMax=0.08f;
	private float zMin=-1.5f;
	private float zMax=1.5f;*/
	private float smoothing = 0.4f;
	//private float yPosition;

	void Awake()
	{
		//yPosition=transform.position.y;
	}


	void Update () {
	
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		if(horizontal != 0f)
		{
			transform.Rotate(new Vector3(0f, horizontal, 0f)*50f*Time.deltaTime);
		}
		if(vertical != 0f)
		{
			if(vertical>0f)
			{
				transform.Translate(Vector3.forward*Time.deltaTime*smoothing);
			}
			else
			{
				transform.Translate(Vector3.back*Time.deltaTime*smoothing);
			}
			//Vector3 newPosition = new Vector3(vertical,transform.position.y, 0f);

			//transform.Translate(newPosition*0.95f*Time.deltaTime);
			
			/*transform.position = new Vector3
				(
					Mathf.Clamp(transform.position.x, xMin, xMax), 
					transform.position.y, 
					Mathf.Clamp(transform.position.z, zMin, zMax)
				);*/
		}

		if(Input.GetKey(KeyCode.I))
		{
			transform.Translate(Vector3.up*Time.deltaTime*smoothing);
		}
		if(Input.GetKey(KeyCode.K))
		{
			transform.Translate(Vector3.down*Time.deltaTime*smoothing);
		}
		if(Input.GetKey(KeyCode.J))
		{
			transform.Translate(Vector3.left*Time.deltaTime*smoothing);
		}
		if(Input.GetKey(KeyCode.L))
		{
			transform.Translate(Vector3.right*Time.deltaTime*smoothing);
		}

	}
}
