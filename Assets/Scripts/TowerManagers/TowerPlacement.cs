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

	void Start()
	{
	}

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
					draggingNewTower.GetComponent<RadiusIndicator>().removeRadiusIndicator();
					draggingNewTower.GetComponent<TowerClass>().enabled = true;
				}
			}
		}else
		{
			if(Input.GetMouseButtonDown(0))
			{
				//define a "hit" for existing towers (towerPos)
				RaycastHit2D hit = Physics2D.Raycast(towerPos, Vector2.zero);

				//if you hit an existing tower
				if(hit.collider != null)
				{
					//if you have a tower selected and click another tower, deselect the old tower, select the new tower
					if(selectedOld != null)
					{
						selectedOld.GetComponent<RadiusIndicator>().removeRadiusIndicator();
						selectedOld.setSelectExisting(false);
					}

					//selecting a tower
					hit.collider.gameObject.GetComponent<CheckPlaceable>().setSelectExisting(true);
					selectedOld = hit.collider.gameObject.GetComponent<CheckPlaceable>();

					hit.collider.GetComponent<RadiusIndicator>().getRadiusIndicator();

				}else
				{
					//if you have a tower selected and don't click another tower, deselect the old tower
					if(selectedOld != null)
					{
						selectedOld.GetComponent<RadiusIndicator>().removeRadiusIndicator();
						selectedOld.setSelectExisting(false);
					}
				}
			}
		}

		if(hasBeenPlaced)
		{
			HoverOffColliderColor();
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
			HoverOnColliderColor();
			return false;
		}else
		{
			HoverOffColliderColor();
		}
		return true;
	}


	public void SetTower(GameObject sTower)
	{
		hasBeenPlaced = false;
		draggingNewTower = ((GameObject)Instantiate(sTower)).transform;
		checkPlacable = draggingNewTower.GetComponent<CheckPlaceable>();

		draggingNewTower.GetComponent<RadiusIndicator>().getRadiusIndicator();

		sprtRenderer = draggingNewTower.GetComponentInChildren<SpriteRenderer>();
		newColor = sprtRenderer.color;
	}

	void HoverOnColliderColor()
	{
		newColor.r = 200;
		newColor.g = 0;
		newColor.b = 0;
		sprtRenderer.color = newColor;
	}
	void HoverOffColliderColor()
	{
		newColor.r = 1;
		newColor.g = 1;
		newColor.b = 1;
		sprtRenderer.color = newColor;
	}
}
