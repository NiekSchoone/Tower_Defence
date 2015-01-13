using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CameraMovement : MonoBehaviour 
{
	float scrollSpeed = 5f;
	
	// Update is called once per frame
	void Update () 
	{

		if(Input.mousePosition.x >= Screen.width / 1.05f)
		{
			transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed);

		}else if(Input.mousePosition.x <= Screen.width / 90)
		{
			transform.Translate(Vector3.right * Time.deltaTime * -scrollSpeed);
		}
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -26.75f, 2f), transform.position.y, transform.position.z);
	}
}
