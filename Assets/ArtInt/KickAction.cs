using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "ArtInt/Actions/Kick")]
public class KickAction : Action
{
	public override void Act (StateController controller)
	{
		BeADick (controller);
	}
	private void BeADick(StateController controller)
	{
		RaycastHit hit;
		Debug.DrawRay (controller.eyes.position, controller.eyes.forward.normalized * controller.aistats.kickRange, Color.red);
		if (Physics.SphereCast (controller.eyes.position, controller.aistats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.aistats.kickRange)
		    && hit.collider.CompareTag ("Player")) {
			if (controller.CheckIfCountDownElapsed (controller.aistats.kickRate)) {
				controller.jerkAttack.Kick (controller.aistats.kickForce, controller.aistats.kickDamage);
			}
		}
	}
}

