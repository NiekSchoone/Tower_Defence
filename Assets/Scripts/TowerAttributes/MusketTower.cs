using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class MusketTower : TowerClass
{

	protected override void Awake()
	{
		fireRate = 0.75f;
		projectileSpeed = 240;
		towerPrice = 100;
		base.Awake();
	}

	protected override void Update () 
	{		
		radius = 1.4f;
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
		shootAnim.speed = fireRate * 2;

	}
}
