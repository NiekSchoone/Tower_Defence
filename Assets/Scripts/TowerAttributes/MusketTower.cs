﻿using UnityEngine;
using System.Collections;

public class MusketTower : TowerClass
{
	protected override void Start()
	{
		radius = 1.4f;
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

	protected override void AttackEnemy()
	{
		base.AttackEnemy();
	}
}
