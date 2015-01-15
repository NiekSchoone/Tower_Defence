using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 200;
		fortressDamaging = 1000;
		Speed = 2.0f;
	}
	
	protected override void Update()
	{
		base.Update ();
	}
}
