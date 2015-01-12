using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
 
	private float _fortressHealth = 1000;

	void OnTriggerEnter2D (Collider2D fortress) 
	{
		if(fortress.gameObject.tag == "Enemy")
		{
			//fortress.GetComponent<Enemies>().DamageFortress(fortressHealth:);
			Debug.Log("Damage");
		}
	}
}
