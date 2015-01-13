using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class ProjectileClass : MonoBehaviour 
{

	protected float damage;

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
			hit.GetComponent<Enemies>().TakeDamage(damage);
			Destroy(gameObject);
		}	
	}
}
