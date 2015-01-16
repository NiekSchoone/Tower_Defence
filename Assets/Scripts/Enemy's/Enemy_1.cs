using UnityEngine;
using System.Collections;

public class Enemy_1 : Enemy 
{
	protected override void Start () 
	{
<<<<<<< HEAD
		enemyHealth = 100;
		fortressDamaging = 200;
		enemyHealth = 50;
=======
		enemyHealth = 30;
		fortressDamaging = 20;
>>>>>>> origin/master
		speed = 0.75f;
		goldValue = 10;
	}

	protected override void Update()
	{
		base.Update ();
	}
}
