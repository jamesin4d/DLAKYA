using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "ArtInt/Actions/Patrol")]
public class PatrolAction : Action
{
	public override void Act(StateController controller)
	{
		Patrol (controller);
	}

	private void Patrol(StateController controller)
	{
		controller.navMeshAgent.destination = controller.waypointList [controller.nextWaypoint].position;
		controller.navMeshAgent.isStopped = false;
		if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending) {
			controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.waypointList.Count;
		}
	}

}

