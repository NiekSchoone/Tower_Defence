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
		towerPrice = 200;
		fireRate = 0.3f;
		projectileSpeed = 200;
		radius = 1.2f;		
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
			audio.Play();
		}
		if(target == null)
		{
			audio.Stop();
		}
	}
}
