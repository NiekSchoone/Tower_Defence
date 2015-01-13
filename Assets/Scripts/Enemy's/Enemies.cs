using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	protected float enemyHealth;
	public float fortressDamaging;
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
}