using UnityEngine;
using System.Collections;

public class Enemy_3 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 70;
		fortressDamaging = 50;
		speed = 0.5f;
		goldValue = 30;
	}
	
	protected override void Update()
	{
		base.Update ();
	}
}
