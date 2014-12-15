using UnityEngine;
using System.Collections;

public class GrenadierTower : TowerClass 
{
	protected override void Start()
	{
		fireRate = 1f;
		radius = 1.2f;		
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
