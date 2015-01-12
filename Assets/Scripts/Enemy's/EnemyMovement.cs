using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {
	//Making a list for all the waypoints.
	public List<GameObject> waypoints = new List<GameObject>();

	//private variable's.
	private float _speed = 0.75f;
	private int _currentWaypoint;

	
	// Use this for initialization
	void Start () {
		_currentWaypoint = 0;
	}

	// Update is called once per frame
	void Update () 
	{
		if(_currentWaypoint >= (waypoints.Count))
		{
			Destroy ();
		}

		//speed for Enemey.
		float step = _speed * Time.deltaTime;

		//Let him know that he is at the waypoint.
		if (Vector3.Distance(transform.position, waypoints[_currentWaypoint].transform.position) < Random.Range(-0.1f, 0.1f))
			_currentWaypoint++;
		//Let him move to the next waypoint.
		transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentWaypoint].transform.position, step);
		//transform.LookAt(waypoints[_currentWaypoint].transform.position);
	}

	void Destroy(){
		if(_currentWaypoint >= (waypoints.Count - 1))
			Destroy(gameObject);
	}
	
}