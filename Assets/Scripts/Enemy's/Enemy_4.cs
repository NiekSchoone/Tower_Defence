using UnityEngine;
using System.Collections;

public class Enemy_4 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 100;
		fortressDamaging = 100;
		speed = 0.25f;
		goldValue = 50;
	}
	
	protected override void Update()
	{
		base.Update ();
	}
}
