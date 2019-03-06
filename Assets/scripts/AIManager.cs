using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System;

namespace Management
{
	[Serializable]
	public class AIManager
	{
		public Transform spawnpoint;
		[HideInInspector] public GameObject instance;
		[HideInInspector] public List<Transform> wayPointList;
		private StateController stateController;

		public void SetupAI(List<Transform> wayPointList)
		{
		stateController = instance.GetComponent<StateController> ();
		stateController.SetupAI (true, wayPointList);
		}

	}
}
