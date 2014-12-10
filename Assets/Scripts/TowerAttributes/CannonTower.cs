using UnityEngine;
using System.Collections;

public class CannonTower : TowerClass
{
	protected override void Start()
	{
		radius = 1.6f;
		base.Start();
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
