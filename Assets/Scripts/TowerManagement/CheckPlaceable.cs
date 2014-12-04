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

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

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
}
