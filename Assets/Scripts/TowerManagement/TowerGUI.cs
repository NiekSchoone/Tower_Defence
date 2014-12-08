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
	private int colums = 2;

	// Use this for initialization
	void Start () 
	{
		towerPlacer = GetComponent<TowerPlacement>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI()
	{
		for(int i = 0; i < towerArray.Length; i++)
		{
			float calcX = (Screen.width/1.4f) + i%colums*(Screen.width/8);
			float calcY = (Screen.height/ 15) + Mathf.Floor(i / colums) * (Screen.height / 6);

			if(GUI.Button(new Rect(calcX, calcY, 60, 60) ,textureArray[i]))
			{
				towerPlacer.setTower(towerArray[i]);
			}
		}

	}
	
}
