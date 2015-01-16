using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
 
	public float _fortressHealth;
	[SerializeField]
	private Canvas can;

	void OnTriggerEnter2D (Collider2D fortress) 
	{

		if(fortress.gameObject.tag == "Enemy")
		{
			float DamageFort = fortress.GetComponent<Enemy>().fortressDamaging;
			_fortressHealth = _fortressHealth - DamageFort;
			can.GetComponent<HealthBar>().UpdateHealth(_fortressHealth);
			if(_fortressHealth <= 0){
				Application.LoadLevel("Menu");
			}
		}
	}
}
