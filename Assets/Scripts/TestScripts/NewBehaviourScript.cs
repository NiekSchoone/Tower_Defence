using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {


	public LayerMask towerMask;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mouseFollow = Input.mousePosition;
		mouseFollow = new Vector3(mouseFollow.x, mouseFollow.y, -transform.position.z);
		Vector3 towerPos = camera.ScreenToWorldPoint(mouseFollow);
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit = new RaycastHit();
			Ray ray = new Ray(new Vector3(towerPos.x, towerPos.y, 0), Vector3.down);
			if(Physics.Raycast(ray, out hit, Mathf.Infinity, towerMask))
			{
				Debug.Log(hit.collider.name);
			}
		}
	}
}
