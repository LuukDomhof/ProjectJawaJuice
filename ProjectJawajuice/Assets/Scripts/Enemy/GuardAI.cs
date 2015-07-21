using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {

	public NavMeshAgent agent;

	public GameObject target;

	public float viewAngle = 30f;
	public float maxMissDistance = 2;

	public int waypointIndex = 0;

	public string state = "Patrolling";

	public Transform destination;
	public Transform[] waypoints;






	// Use this for initialization
	void Start () {
		state = "Patrolling";
		destination = waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
	
		agent.destination = destination.position;

		switch(state){
		case "Patrolling":
			Patrolling ();
			break;

		case "Chasing":
			Chasing();
			break;
		}

	}

	void Patrolling(){
		destination = waypoints[waypointIndex];
		if(Vector3.Distance(waypoints[waypointIndex].position, this.transform.position) <= maxMissDistance){
			if(waypointIndex < waypoints.Length -1){
				waypointIndex++;
			}else{
				waypointIndex = 0;
			}
		}
	}

	void Sight(){

	}

	void Chasing(){

	}

	void Attacking(){
	
	}
}
