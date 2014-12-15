using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class RadiusIndicator : MonoBehaviour 
{
	public float indicatedRadius;

	[SerializeField]
	public GameObject radiusIndicator;

	// Use this for initialization
	public virtual void Start()
	{
		radiusIndicator.transform.localScale = new Vector3(indicatedRadius,indicatedRadius,1);
		getRadiusIndicator();
	}
	
	public void getRadiusIndicator()
	{
		radiusIndicator.SetActive(true);
	}

	public void removeRadiusIndicator()
	{
		radiusIndicator.SetActive(false);
	}
}
