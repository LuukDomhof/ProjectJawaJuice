using UnityEngine;
using System.Collections;

public class GuardAI : MonoBehaviour {

	public NavMeshAgent agent;

	public GameObject target;

	public float distanceToClosest = 9999f;
	public int index;

	public float viewAngle = 30f;
	public float maxMissDistance = 2;

	public int waypointIndex = 0;

	public string state = "Patrolling";

	public Transform destination;
	public Transform[] waypoints;

	public Color red = Color.red;
	public Color yellow = Color.yellow;






	// Use this for initialization
	void Start () {
		state = "Patrolling";
		destination = waypoints[0];
	}
	
	// Update is called once per frame
	void Update () {
	
		if(state != "None"){
			agent.destination = destination.position;
		}
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

			Debug.DrawLine(this.transform.position,target.transform.position, yellow);
			RaycastHit hit;

			Ray ray = new Ray(this.transform.position,targetDir);

			Physics.Raycast(ray,out hit);

			Debug.DrawLine(this.transform.position,hit.point, red);

			if(hit.collider.tag == target.tag){
				state = "Chasing";
				destination = target.transform;
			}else{
				state = "Patrolling";
			}

		}else{
			state = "Patrolling";
		}
	}

	void Chasing(){

	}

//	void GetClosestWaypoint(){
//		if(state == "Chasing"){
//			for(int i=0;i<waypoints.Length;i++){
//				Debug.Log (i);
//				if(Vector3.Distance(this.transform.position, waypoints[i].position) < distanceToClosest){
//					distanceToClosest = Vector3.Distance(this.transform.position,waypoints[i].position);
//					index = i;
//				}
//				
//				if(i == waypoints.Length -1){
//					Debug.Log ("Setting " + waypointIndex +  " To " + i);
//					waypointIndex = i;
//					state = "Patrolling";
//				}
//			}
//	}
//
//	}

	void Attacking(){
	
	}
}
