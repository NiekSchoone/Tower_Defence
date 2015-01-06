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
		towerPrice = 300;
		fireRate = 2f;
		radius = 1.6f;
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
}
