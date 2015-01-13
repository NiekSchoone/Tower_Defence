using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CustomCursor : MonoBehaviour 
{
	public Texture2D cursorNormal;
	public Texture2D cursorClick;
	public Texture2D cursorDragging;

	private Vector2 hotSpot = Vector2.zero;
	private CursorMode mode = CursorMode.Auto;

	private TowerPlacement dragging;

	// Use this for initialization
	void Start()
	{
		Cursor.SetCursor(cursorNormal, hotSpot, mode);
		dragging = GetComponent<TowerPlacement>();

	}

	void Update()
	{

		if(dragging.draggingNewTower == true && dragging.hasBeenPlaced == false)
		{
			Cursor.SetCursor(cursorDragging, hotSpot, mode);
		}

		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Cursor.SetCursor(cursorClick, hotSpot, mode);
		}
		if(Input.GetKeyUp(KeyCode.Mouse0))
		{
			Cursor.SetCursor(cursorNormal, hotSpot, mode);
		}
	}
}
