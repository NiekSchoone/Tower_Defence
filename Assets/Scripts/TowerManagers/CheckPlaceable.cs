using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
* ...
* @author Niek Schoone
**/

public class CheckPlaceable : MonoBehaviour 
{
	public Texture2D upgradeTexture;
	
	public List<Collider2D> colliders = new List<Collider2D>();

	private bool selectedIsExisting;

	public TowerClass getUpgrade;

	void Start()
	{
		getUpgrade = GetComponent<TowerClass>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Tower" || col.tag == "Path" || col.tag == "Border")
		{
			colliders.Add(col);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Tower" || col.tag == "Path" || col.tag == "Border")
		{
			colliders.Remove(col);
		}
	}

	void OnGUI()
	{
		if(selectedIsExisting)
		{
			if(GUI.Button(new Rect(Screen.width / 2, Screen.height / 1.15f, 40,40), upgradeTexture))
			{
				getUpgrade.UpgradeTower();
			}
		}
	}
	
	public void setSelectExisting(bool setSE)
	{
		selectedIsExisting = setSE;
	}
}
