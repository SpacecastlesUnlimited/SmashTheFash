using UnityEngine;
using System.Collections;

public class MoveAlongPath : MonoBehaviour {

	public Transform[] waypoints;
	public float tolerance;
	public bool reachedEnd;
	private NavMeshAgent agent;
	private Transform waypoint;
	private int pos;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		foreach (var p in waypoints)
			p.gameObject.SetActive (false);
		pos = 0;
		waypoint = waypoints [pos];
		waypoint.gameObject.SetActive(true);
		agent.SetDestination (waypoint.position);
		reachedEnd = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!reachedEnd && (transform.position - waypoint.position).magnitude <= tolerance) {
			waypoint.gameObject.SetActive(false);
			pos++;
			if (pos >= waypoints.Length) {
				reachedEnd = true;
				return;
			}
			waypoint = waypoints [pos];
			waypoint.gameObject.SetActive(true);
			agent.SetDestination (waypoint.position);
		}
	}
}
