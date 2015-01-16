using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 100;
		fortressDamaging = 500;
		enemyHealth = 50;
		speed = 0.75f;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
