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
	public TowerClass currentTower;

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
			currentTower = towerArray[i].GetComponent<TowerClass>();

			float calcX = (Screen.width/1.185f) + i%colums*(Screen.width/12.5f);
			float calcY = (Screen.height/ 15) + Mathf.Floor(i / colums) * (Screen.height / 9);

			//if the player does not have enough gold, the buttons will be dissabled
			if(gold.playerOwnedCoin <= currentTower.towerPrice)
			{
				GUI.enabled = false;
			}
			if(GUI.Button(new Rect(calcX, calcY, 40, 40) ,textureArray[i]))
			{
				gold.playerOwnedCoin -= currentTower.towerPrice;
				towerPlacer.SetTower(towerArray[i]);
				Debug.Log(currentTower.towerPrice);

			}
		}

	}
	
}
