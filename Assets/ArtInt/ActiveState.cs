using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu (menuName = "ArtInt/Decisions/ActiveState")]

public class ActiveState : Decision
{
	public override bool Decide(StateController controller)
	{	
		bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
		return chaseTargetIsActive;
	}
	
}

