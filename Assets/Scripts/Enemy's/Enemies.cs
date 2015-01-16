using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	protected float enemyHealth;
	public float fortressDamaging;
	protected ProjectileClass projectileClass;
	public Animator anim;

	protected virtual void Start () 
	{
		anim.GetComponent<Animator>();
	}

	public void TakeDamage(float damage)
	{
		enemyHealth = enemyHealth - damage;

		if(enemyHealth <= 0)
		{
			anim.SetBool("IsDead", true);
		}
	}
	public void KillEnemy()
	{
		Destroy(gameObject);
		Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin += 10;
	}
}