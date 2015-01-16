using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 50;
		fortressDamaging = 10;
		speed = 1f;
		goldValue = 20;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
