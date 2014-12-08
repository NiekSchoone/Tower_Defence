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
	private bool canInstantiateNewTower;

	private SpriteRenderer sprtRenderer;
	private Color newColor;

	public LayerMask towerMask;

	private CheckPlaceable selectedOld;
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 mouseFollow = Input.mousePosition;
		mouseFollow = new Vector3(mouseFollow.x, mouseFollow.y, -transform.position.z);
		Vector3 towerPos = camera.ScreenToWorldPoint(mouseFollow);

		if(draggingNewTower != null && !hasBeenPlaced)
		{
			draggingNewTower.position = new Vector3(towerPos.x,towerPos.y, 0);

			newColor.a = 0.5f;
			sprtRenderer.color = newColor;

			if(Input.GetMouseButtonDown(0))
			{
				if(notColliding())
				{
					newColor.a = 1;
					sprtRenderer.color = newColor;
					hasBeenPlaced = true;
				}
			}
		}else
		{

			if(Input.GetMouseButtonDown(0))
			{
				RaycastHit2D hit = Physics2D.Raycast(towerPos, Vector2.zero);

				if(hit.collider != null)
				{
					if(selectedOld != null)
					{
						selectedOld.setSelectExisting(false);
					}
					Debug.Log (hit.collider.name);
					hit.collider.gameObject.GetComponent<CheckPlaceable>().setSelectExisting(true);
					selectedOld = hit.collider.gameObject.GetComponent<CheckPlaceable>();
				}else
				{
					if(selectedOld != null)
					{
						selectedOld.setSelectExisting(false);
					}
				}
			}
		}

		if(hasBeenPlaced)
		{
			hoverOffColliderColor();
		}

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
