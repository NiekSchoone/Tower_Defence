using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CheckClickOnBackground : MonoBehaviour 
{
	public TowerPlacement changeBool;

	void OnMouseOver()
	{
		changeBool.onBackgroundClick = true;
	}
	void OnMouseExit()
	{
		changeBool.onBackgroundClick = false;
	}
}
