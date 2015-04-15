using UnityEngine;
using System.Collections;

public class GoodPeopleNavigation : MonoBehaviour {
	
	public Transform target;
	private NavMeshAgent agent;

	public void SetDestination(Transform Target) {
		target = Target;
		agent.SetDestination (target.position);
	}

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		if (target != null)
			agent.SetDestination (target.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
