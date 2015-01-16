using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {
	
	protected float enemyHealth;
	public float fortressDamaging;
	protected float speed;
	protected ProjectileClass projectileClass;

	//Making a list for all the waypoints.
	[SerializeField]
	protected List<GameObject> waypoints = new List<GameObject>();
	
	//private variable's.
	private int _currentWaypoint;

	public Animator anim;

	protected virtual void Start () 
	{
		_currentWaypoint = 0;
		anim.GetComponent<Animator>();

	}
	protected virtual void Update () 
	{
		if(_currentWaypoint >= (waypoints.Count - 1))
		{
			Destroy ();
		}
		
		//speed for Enemey.
		float step = speed * Time.deltaTime;
		
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
			anim.SetBool("IsDead", true);
			speed -= speed;
			gameObject.layer = 0;
			collider.enabled = false;
		}
	}
	public void Destroy(){
		if(_currentWaypoint >= (waypoints.Count - 1))
			Destroy(gameObject);
	}

	public void KillEnemy()
	{
		Destroy(gameObject);
		Camera.main.gameObject.GetComponent<GoldScript>().playerOwnedCoin += 10;
	}

}