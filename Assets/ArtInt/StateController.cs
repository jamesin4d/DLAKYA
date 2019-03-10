using UnityEngine;
using UnityEngine.AI;
//using Complete;
using System.Collections;
using System.Collections.Generic;
public class StateController : MonoBehaviour
{
	public State currentState;
	public State remainState;
	public AIStats aistats;
	public Transform eyes;
	[HideInInspector] public NavMeshAgent navMeshAgent;
	[HideInInspector] public JerkAttack jerkAttack;
	[HideInInspector] public List<Transform> waypointList;
	[HideInInspector] public int nextWaypoint;
	[HideInInspector] public Transform chaseTarget;
	[HideInInspector] public float stateTimeElapsed;

	private bool aiActive;
	// Use this for initialization
	void Start ()
	{
		jerkAttack = this.GetComponent<JerkAttack> ();
		//navMeshAgent = this.GetComponent<NavMeshAgent> ();
	}

	public void SetupAI(bool activationFromManager, List<Transform> waypointsFromManager)
	{
		waypointList = waypointsFromManager;
		aiActive = activationFromManager;
		if (aiActive) {
			navMeshAgent = GetComponent<NavMeshAgent> ();
			navMeshAgent.enabled = true;
		} else {
			navMeshAgent.enabled = false;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if (!aiActive)
			return;
		currentState.UpdateState (this);
	
	}
	void OnDrawGizmos()
	{
		if (currentState != null && eyes != null) {
			Gizmos.color = currentState.sceneGizmoColor;
			Gizmos.DrawWireSphere (eyes.position, aistats.lookSphereCastRadius);
		}
	}
	public void TransitionToState(State nextState){
		if (nextState != remainState) {
			currentState = nextState;
			OnExitState ();
		}
	}
	public bool CheckIfCountDownElapsed(float duration) {
		stateTimeElapsed += Time.deltaTime;
		return (stateTimeElapsed >= duration);
	}
	private void OnExitState () {
		stateTimeElapsed = 0;
	}
}

