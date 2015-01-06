using UnityEngine;
using System.Collections;

/**
* ...
* @author Niek Schoone
**/

public class GrenadierTower : TowerClass 
{
	protected override void Awake()
	{
		towerPrice = 200;
		fireRate = 1f;
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
}
