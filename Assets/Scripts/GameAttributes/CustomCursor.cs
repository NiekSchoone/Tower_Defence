using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CustomCursor : MonoBehaviour 
{
	public Texture2D cursorTexture;
	private Vector2 hotSpot = Vector2.zero;
	private CursorMode mode = CursorMode.Auto;

	// Use this for initialization
	void Start () 
	{
		Cursor.SetCursor(cursorTexture, hotSpot, mode);
	}
}
