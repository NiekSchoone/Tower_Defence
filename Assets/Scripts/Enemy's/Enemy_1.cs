using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 100;
		fortressDamaging = 200;
		speed = 0.75f;
		goldValue = 10;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
