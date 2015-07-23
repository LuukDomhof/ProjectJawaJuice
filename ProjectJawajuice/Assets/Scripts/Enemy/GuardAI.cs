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

	public Color debug = Color.green;






	// Use this for initialization
	void Start () {
		state = "Patrolling";
		destination = waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
	
		agent.destination = destination.position;
		Sight();


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

		Vector3 targetDir = target.transform.position - this.transform.position;
		Vector3 forwardDir = this.transform.forward;

		float angle = Vector3.Angle(forwardDir,targetDir);

		if(angle <= viewAngle && angle >= -viewAngle){
			Debug.DrawLine(this.transform.position,target.transform.position, debug);
		}
	}

	void Chasing(){

	}

	void Attacking(){
	
	}
}
