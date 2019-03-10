using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "ArtInt/Decisions/Look")]
public class LookDecision : Decision {

	public override bool Decide(StateController controller)
	{
		bool targetVisible = Look (controller);
		return targetVisible;
	}

	private bool Look(StateController controller)
	{
		Debug.Log ("looking");
		RaycastHit hit;
		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.aistats.lookRange, Color.green);
		if (Physics.SphereCast (controller.eyes.position, controller.aistats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.aistats.lookRange)
		    && hit.collider.CompareTag ("Player")) {
			Debug.Log ("spotted");
			controller.chaseTarget = hit.transform;
			return true;
		} else {
			return false;
		}
	}
}
