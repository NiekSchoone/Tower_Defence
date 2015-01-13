using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
 
	public float _fortressHealth = 1000;

	void OnTriggerEnter2D (Collider2D fortress) 
	{

		if(fortress.gameObject.tag == "Enemy")
		{
			float DamageFort = fortress.GetComponent<Enemies>().fortressDamaging;
			_fortressHealth = _fortressHealth - DamageFort;
			
			if(_fortressHealth <= 0){
				Destroy(gameObject);
			}
		}
	}
}
