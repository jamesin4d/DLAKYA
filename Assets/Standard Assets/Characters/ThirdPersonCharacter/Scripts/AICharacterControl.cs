using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
		public float sightRange = 20f;
		public float distanceToTarget = 0;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
			target = GameObject.FindGameObjectWithTag("Player").transform;

	        agent.updateRotation = false;
	        agent.updatePosition = true;
        }


        private void Update()
        {
			distanceToTarget = Vector3.Distance(this.transform.position, target.transform.position);
			//Debug.Log("Distance to player = " + distanceToTarget.ToString("0.0"));
            if (target != null)
				if(distanceToTarget < sightRange){
					agent.SetDestination(target.position);
				}
				// else {
				// 	agent.SetDestination(this.transform.position);
				// }

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
