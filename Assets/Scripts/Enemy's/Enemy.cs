using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	protected float enemyHealth;
	public float fortressDamaging;
	protected float Speed;
	protected ProjectileClass projectileClass;

	//Making a list for all the waypoints.
	public List<GameObject> waypoints = new List<GameObject>();
	
	//private variable's.
	private int _currentWaypoint;

	protected virtual void Start () 
	{
		_currentWaypoint = 0;
	}
	protected virtual void Update () 
	{
		if(_currentWaypoint >= (waypoints.Count - 1))
		{
			Destroy ();
		}
		
		//speed for Enemey.
		float step = Speed * Time.deltaTime;
		
		//Let him know that he is at the waypoint.
		if (Vector3.Distance(transform.position, waypoints[_currentWaypoint].transform.position) < Random.Range(-0.1f, 0.1f))
			_currentWaypoint++;
		//Let him move to the next waypoint.
		transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position, step);
		//transform.LookAt(waypoints[_currentWaypoint].transform.position);
	}

	public void TakeDamage(float damage){
		enemyHealth = enemyHealth - damage;

		if(enemyHealth <= 0){
			Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin += 10;
			Destroy(gameObject);
		}
	}
	public void Destroy(){
		if(_currentWaypoint >= (waypoints.Count - 1))
			Destroy(gameObject);
	}
}