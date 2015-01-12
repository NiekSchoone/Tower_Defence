using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	protected float enemyHealth;
	protected float fortressDamage;
	protected ProjectileClass projectileClass;

	protected virtual void Start () 
	{
		
	}
	protected virtual void Update () 
	{

	}

	public void TakeDamage(float damage){
		enemyHealth = enemyHealth - damage;

		if(enemyHealth <= 0){
			Destroy(gameObject);
		}
	}
	public void DamageFortress(float fortressHealth){
		fortressHealth = fortressHealth - fortressDamage;

		if(fortressHealth <= 0){
			Debug.Log("Dood jonge!");
		}
	}
}