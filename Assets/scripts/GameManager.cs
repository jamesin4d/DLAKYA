using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Management 
{
public class GameManager : MonoBehaviour
	{
		public AIManager[] AIS;
		public List<Transform> wayPointsForAI;
		public GameObject[] AIPrefabs;


	// Use this for initialization
		void Start ()
		{
			SpawnJerks ();
			Debug.Log ("game man start");
		}
		private void SpawnJerks() {
			for (int i = 0; i < AIS.Length; i++) {
				
				Debug.Log ("supposed to be instantiating");
				AIS [i].instance = Instantiate (AIPrefabs [i], AIS [i].spawnpoint.position, AIS [i].spawnpoint.rotation) as GameObject;
				AIS [i].SetupAI (wayPointsForAI);
			}
		} 
	
	// Update is called once per frame
		void Update ()
		{
	
		}
	}
}
