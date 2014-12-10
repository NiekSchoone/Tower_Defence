using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		origin = new Vector2(transform.position.x, transform.position.y);

		Debug.Log(origin);

		enemyTargetingArray = Physics2D.OverlapCircleAll(origin, radius, EnemyLayer);
		if(enemyTargetingArray.Length > 0)
		{
			TargetEnemy();
		}
		if(enemyTargetingArray.Length < 1)
		{
			target = null;
		}
		AttackEnemy();

		Debug.Log(target);
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

	protected virtual IEnumerator AttackEnemy()
	{
		//if(target != null)
		//{
			//Vector2 direction = target - origin;
			//direction.Normalize();
			//GameObject projectile = (GameObject)Instantiate(ammo, transform.position, transform.rotation);
		//}
	}	
}
