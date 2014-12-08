using UnityEngine;
using System.Collections;

public class TowerClass : MonoBehaviour
{
	[SerializeField]
	protected LayerMask EnemyLayer;

	protected float radius = 2f;
	protected GameObject origin; 

	[SerializeField]
	protected Collider2D[] enemyTargetingArray;

	protected virtual void Update()
	{

		Debug.Log(enemyTargetingArray.Length);
		enemyTargetingArray = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y), radius, EnemyLayer);

	}

	protected virtual void TargetEnemy()
	{

	}

}
