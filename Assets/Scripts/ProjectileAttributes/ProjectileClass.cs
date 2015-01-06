using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class ProjectileClass : MonoBehaviour 
{

	protected float damageDealt;

	protected virtual void Start () 
	{
		
	}
	
	protected virtual void Update () 
	{
	
	}

	protected virtual void OnTriggerEnter2D(Collider2D hit)
	{
		if(hit.tag == "Enemy")
		{
			/*EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			
			if(enemyHealth != null)
			{
				enemyHealth.TakeDamage (damageDealt);
			}*/
			Destroy(gameObject);
			Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin += 10;
		}	
	}
}
