using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class CannonTower : TowerClass
{
	protected override void Awake()
	{
		fireRate = 1.6f;
		projectileSpeed = 160;
		radius = 1.6f;
		towerPrice = 300;
		base.Awake();
	}

	protected override void Update () 
	{
		base.Update();
	}
	
	protected override void TargetEnemy()
	{
		base.TargetEnemy();
	}

	protected override void AttackEnemy()
	{
		base.AttackEnemy();
		if(target != null)
		{
			audio.PlayOneShot(shootSound);
		}
		shootAnim.speed = fireRate / 4;

	}
}
