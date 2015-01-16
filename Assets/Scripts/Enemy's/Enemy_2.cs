﻿using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 10;
		fortressDamaging = 200;
		speed = 0.5f;
		goldValue = 20;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
