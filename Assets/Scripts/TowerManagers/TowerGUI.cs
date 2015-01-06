using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class TowerGUI : MonoBehaviour 
{
	public GameObject[] towerArray;
	public Texture2D[]	textureArray;
	private TowerPlacement towerPlacer;
	private GoldScript gold;

	private int colums = 2;

	// Use this for initialization
	void Start () 
	{
		towerPlacer = GetComponent<TowerPlacement>();
		gold = GetComponent<GoldScript>();
	}

	void OnGUI()
	{
		for(int i = 0; i < towerArray.Length; i++)
		{
			TowerClass currentTower = towerArray[i].GetComponent<TowerClass>();
			float calcX = (Screen.width/1.4f) + i%colums*(Screen.width/8);
			float calcY = (Screen.height/ 15) + Mathf.Floor(i / colums) * (Screen.height / 6);

			//if the player does not have enough gold, the buttons will be dissabled
			if(gold.playerOwnedCoin <= currentTower.towerPrice)
			{
				GUI.enabled = false;
			}
			if(GUI.Button(new Rect(calcX, calcY, 60, 60) ,textureArray[i]))
			{
				gold.playerOwnedCoin -= currentTower.towerPrice;
				towerPlacer.SetTower(towerArray[i]);
				Debug.Log(currentTower.towerPrice);

			}
		}

	}
	
}
