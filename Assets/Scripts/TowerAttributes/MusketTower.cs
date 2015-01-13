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
		towerPrice = 100;
		fireRate = 0.75f;
		projectileSpeed = 200;
		radius = 1.4f;
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
	}
}
