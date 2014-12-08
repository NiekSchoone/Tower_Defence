using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
* ...
* @author Niek Schoone
**/

public class CheckPlaceable : MonoBehaviour 
{
	public List<Collider2D> colliders = new List<Collider2D>();
	private bool selectedIsExisting;

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Tower" || col.tag == "Path")
		{
			colliders.Add(col);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Tower" || col.tag == "Path")
		{
			colliders.Remove(col);
		}
	}
	void OnGUI()
	{
		if(selectedIsExisting)
		{
			GUI.Button(new Rect(Screen.width / 2, Screen.height / 1.25f, 100,60), name);
		}
	}
	
	public void setSelectExisting(bool setSE)
	{
		selectedIsExisting = setSE;
	}
}
