using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TowerClass : MonoBehaviour
{
	[SerializeField]
	protected LayerMask EnemyLayer;
	protected float radius;

	[SerializeField]
	protected GameObject radiusIndicator;

	protected GameObject target;

	[SerializeField]
	protected GameObject ammo;

	protected float fireRate;

	protected float coolDown = 1;

	protected float projectileSpeed = 100;

	[SerializeField]
	protected Collider2D[] enemyTargetingArray;
	//protected List<Collider2D> enemyTargetingArray = new List<Collider2D>();

	protected Vector2 origin;

	protected virtual void Start()
	{
		radiusIndicator.transform.localScale = new Vector3(radius,radius,1);
		getRadiusIndicator();
	}
	protected virtual void Update()
	{
		EnemiesEnter();

		if(enemyTargetingArray.Length > 0)
		{
			TargetEnemy();
		}
		if(enemyTargetingArray.Length < 1)
		{
			target = null;
		}
		if(Time.time >= coolDown)
		{
			AttackEnemy();
		}


	}

	protected void EnemiesEnter()
	{
		origin = new Vector2(transform.position.x, transform.position.y);
		enemyTargetingArray = Physics2D.OverlapCircleAll(origin, radius, EnemyLayer);
		for (int i = 0; i < enemyTargetingArray.Length; i++) 
		{
			if(enemyTargetingArray[i].transform.position.x < enemyTargetingArray[0].transform.position.x)
			{
				enemyTargetingArray[0] = enemyTargetingArray[i];
			}
		}
	}

	public void getRadiusIndicator()
	{
		radiusIndicator.SetActive(true);
	}
	public void removeRadiusIndicator()
	{
		radiusIndicator.SetActive(false);
	}

	protected virtual void TargetEnemy()
	{
		target = enemyTargetingArray[0].gameObject;
	}

	protected virtual void AttackEnemy()
	{
		if(target != null)
		{
			Vector2 myPos = new Vector2(this.transform.position.x, this.transform.position.y);
			Vector2 targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
			Vector2 fireAt = targetPos - myPos;
			Quaternion rotation = Quaternion.Euler( 0, 0, Mathf.Atan2 ( fireAt.y, fireAt.x ) * Mathf.Rad2Deg);
			GameObject projectile = (GameObject)Instantiate(ammo, transform.position, rotation);
			projectile.rigidbody2D.AddForce(fireAt * projectileSpeed);
			coolDown = Time.time + fireRate;
		}
	}	
}
