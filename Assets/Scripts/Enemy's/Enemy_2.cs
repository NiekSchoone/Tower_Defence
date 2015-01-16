using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemy 
{
	protected override void Start () 
	{
<<<<<<< HEAD
		enemyHealth = 10;
		fortressDamaging = 200;
		speed = 0.5f;
=======
		enemyHealth = 50;
		fortressDamaging = 10;
		speed = 1f;
>>>>>>> origin/master
		goldValue = 20;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
