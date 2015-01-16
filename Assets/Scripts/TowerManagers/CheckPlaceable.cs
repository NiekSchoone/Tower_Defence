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
			if(getUpgrade.towerLevel3 == true || Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin <= 100)
			{
				GUI.enabled = false;
			}
			if(GUI.Button(new Rect(Screen.width / 2, Screen.height / 1.15f, 40,40), upgradeTexture))
			{
				Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin -= 100;
				if(getUpgrade.towerLevel2 == false)
				{
					getUpgrade.towerLevel2 = true;
					getUpgrade.towerLevel1 = false;
				}else if(getUpgrade.towerLevel2 == true)
				{
					getUpgrade.towerLevel3 = true;
					getUpgrade.towerLevel2 = false;
				}
				getUpgrade.UpgradeTower();
			}
		}
	}
	
	public void setSelectExisting(bool setSE)
	{
		selectedIsExisting = setSE;
	}
}
