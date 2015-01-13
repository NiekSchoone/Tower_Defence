using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class TowerPlacement : MonoBehaviour 
{
	private CheckPlaceable checkPlacable;
	private CheckPlaceable selectedOld;
	private TowerGUI getCurrentTower;

	public Transform draggingNewTower;

	public  bool onBackgroundClick;
	public	bool hasBeenPlaced;
	private bool canInstantiateNewTower;
	
	private SpriteRenderer sprtRenderer;
	private Color newColor;

	public LayerMask towerMask;

	public Texture2D trashCanTex;

	public AudioClip noPlaceSound;
	public AudioClip placeSound;

	// Update is called once per frame
	void Update () 
	{
		Vector3 mouseFollow = Input.mousePosition;
		mouseFollow = new Vector3(mouseFollow.x, mouseFollow.y, -transform.position.z);
		Vector3 towerPos = camera.ScreenToWorldPoint(mouseFollow);

		if(draggingNewTower != null && !hasBeenPlaced)
		{
			sprtRenderer.sortingOrder = 12;

			draggingNewTower.position = new Vector3(towerPos.x,towerPos.y, 0);

			newColor.a = 0.5f;
			sprtRenderer.color = newColor;

			if(Input.GetMouseButtonDown(0))
			{

				if(notColliding())
				{
					audio.PlayOneShot(placeSound);

					sprtRenderer.sortingOrder = 4;			

					newColor.a = 1;
					sprtRenderer.color = newColor;
					hasBeenPlaced = true;
					draggingNewTower.GetComponent<RadiusIndicator>().removeRadiusIndicator();
					draggingNewTower.GetComponent<TowerClass>().enabled = true;
				}else
				{
					audio.PlayOneShot(noPlaceSound);
				}
			}
		}else
		{
			if(Input.GetMouseButtonDown(0))
			{
				//define a "hit" for existing towers (towerPos)
				RaycastHit2D hitTower = Physics2D.Raycast(towerPos, Vector2.zero);


				//if you hit an existing tower
				if(hitTower.collider != null && hitTower.collider.gameObject.tag == "Tower")
				{
					//if you have a tower selected and click another tower, deselect the old tower, select the new tower
					if(selectedOld != null)
					{
						selectedOld.GetComponent<RadiusIndicator>().removeRadiusIndicator();
						selectedOld.setSelectExisting(false);
					}

					//selecting a tower

					//upgradeButton.SetActive(true);
					hitTower.collider.gameObject.GetComponent<CheckPlaceable>().setSelectExisting(true);
					selectedOld = hitTower.collider.gameObject.GetComponent<CheckPlaceable>();

					hitTower.collider.GetComponent<RadiusIndicator>().getRadiusIndicator();

				}else
				{
					//upgradeButton.SetActive(false);

					//if you have a tower selected and don't click another tower, deselect the old tower
					if(selectedOld != null && onBackgroundClick == true)
					{
						//upgradeButton.SetActive(false);
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

	void OnGUI()
	{
		GUI.enabled = false;
		if(draggingNewTower && hasBeenPlaced != true)
		{
			GUI.enabled = true;
		}

		if(GUI.Button(new Rect(Screen.width / 1.16f, Screen.height / 1.15f, 80, 60), trashCanTex))
		{
			Destroy(draggingNewTower.gameObject);
			Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin += Camera.main.gameObject.GetComponent<TowerGUI>().currentTower.towerPrice;
		}
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
