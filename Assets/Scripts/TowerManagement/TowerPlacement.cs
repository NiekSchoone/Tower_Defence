using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class TowerPlacement : MonoBehaviour 
{
	private CheckPlaceable checkPlacable;
	private Transform draggingNewTower;
	private bool hasBeenPlaced;
	private SpriteRenderer sprtRenderer;
	private Color newColor;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(draggingNewTower != null && !hasBeenPlaced)
		{
			Vector3 mouseFollow = Input.mousePosition;
			mouseFollow = new Vector3(mouseFollow.x, mouseFollow.y, - transform.position.z);
			Vector3 towerPos = camera.ScreenToWorldPoint(mouseFollow);
			draggingNewTower.position = new Vector3(towerPos.x,towerPos.y, 0);

			newColor.a = 0.5f;
			sprtRenderer.color = newColor;

			if(Input.GetMouseButtonDown(0))
			{
				if(notColliding())
				{
					newColor.a = 1;
					hoverOffColliderColor();
					sprtRenderer.color = newColor;
					hasBeenPlaced = true;
				}
			}
		}/*else
		{
			if(Input.GetMouseButtonDown(0) && gameObject.tag == "Tower".Contains(Input.mousePosition))
			{

			}
		}*/
		if(checkPlacable != null)
		{
			notColliding();
		}
	}
	
	bool notColliding()
	{
		if(checkPlacable.colliders.Count > 0)
		{
			hoverOnColliderColor();
			return false;
		}else
		{
			hoverOffColliderColor();
		}
		return true;
	}

	public void setTower(GameObject sTower)
	{
		hasBeenPlaced = false;
		draggingNewTower = ((GameObject)Instantiate(sTower)).transform;
		checkPlacable = draggingNewTower.GetComponent<CheckPlaceable>();
		sprtRenderer = draggingNewTower.GetComponentInChildren<SpriteRenderer>();
		newColor = sprtRenderer.color;
	}

	void hoverOnColliderColor()
	{
		newColor.r = 200;
		newColor.g = 0;
		newColor.b = 0;
		sprtRenderer.color = newColor;
	}
	void hoverOffColliderColor()
	{
		newColor.r = 1;
		newColor.g = 1;
		newColor.b = 1;
		sprtRenderer.color = newColor;
		
	}
}
