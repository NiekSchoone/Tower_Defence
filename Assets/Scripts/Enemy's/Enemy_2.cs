using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemy 
{
	protected override void Start () 
	{
		enemyHealth = 10;
		fortressDamaging = 1000;
		Speed = 2.0f;
	}
<<<<<<< HEAD
=======
	
	protected override void Update()
	{
		base.Update ();
	}
>>>>>>> origin/master
}
