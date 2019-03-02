using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcLauncher : MonoBehaviour {

	[Tooltip("This value is true if the object is a launcher.")]
	public bool isLauncher = true;
	float timeInAir = 2;
	[Range(0.1f,1)]
	public float timePerUnit = .5f;
	public Transform target;


	void OnTriggerEnter(Collider other) {
		if(isLauncher) {
			if(other.gameObject.CompareTag("Player")) {
				Vector3 delta = target.position - this.transform.position;		// To - from = the vector that represents the difference between two positions
				Vector3 flatDelta = delta;			// setting up for the XZ position, doesn't care about the y-axis
				flatDelta.y = 0;					// ignoring the y-axis
				float flatDistance = flatDelta.magnitude;		// the distance between the two positions

				timeInAir = Mathf.Max(1, (flatDistance - Mathf.Max(0, -delta.y))) * (timePerUnit * .1f);		// messes with arcs.
				print("Time in air = " + flatDistance * (timePerUnit * .1f));


				float flatSpeed = flatDistance / timeInAir;		// the constant speed that we'll move on the XZ plane towards the target

				float deltaHeight = delta.y;		// the value of the y
				// gravity
				float g = -Physics.gravity.magnitude;			//use unity gravity - whatever it's set to.
				float ySpeed = (deltaHeight - 0.5f * g * timeInAir * timeInAir) / timeInAir;		//
				Vector3 flatVelocity = flatDelta.normalized * flatSpeed;		//xz velocity
				Vector3 vel = flatVelocity + new Vector3(0,ySpeed,0);

				other.transform.position = this.transform.position;
				other.GetComponent<Rigidbody>().velocity = vel;
			
			}
		} else {
			print("Hit target");
		}
		
	}


}
