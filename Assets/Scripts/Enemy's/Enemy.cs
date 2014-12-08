using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform[] waypoints;

	private float speed = 1;
	private int currentWaypoint;


	// Use this for initialization
	void Start () {
		currentWaypoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//target = waypoints[currentWaypoint].position;
		float step = speed * Time.deltaTime;
		if(transform.position == waypoints[currentWaypoint].transform.position)
		{
			currentWaypoint++;
		}
		else
		{
			transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, step);
		}
	}
}
