﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu (menuName = "ArtInt/Actions/Chase")]
public class ChaseAction : Action
{
	public override void Act (StateController controller) {
		Chase (controller);
	}

	private void Chase (StateController controller)
	{
		controller.navMeshAgent.destination = controller.chaseTarget.position;
		controller.navMeshAgent.isStopped = false;
	}
}

