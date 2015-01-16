using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class GatlingGunTower : TowerClass 
{
	protected override void Awake()
	{
		fireRate = 0.3f;
		projectileSpeed = 200;
		towerPrice = 1000;
		base.Awake();
	}

	protected override void Update () 
	{
		radius = 1.6f;	

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
			audio.Play();
		}
		if(target == null)
		{
			audio.Stop();
		}
		shootAnim.speed = fireRate * 5;

	}
}
