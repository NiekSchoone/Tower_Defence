using UnityEngine;
using System.Collections;

public class Enemy_2 : Enemies 
{
	protected override void Start () 
	{
		enemyHealth = 10;
		fortressDamaging = 1000;
	}
}
