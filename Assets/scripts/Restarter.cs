using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
	 
	{
	private Scene currentScene;
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
			currentScene = SceneManager.GetActiveScene();	
			SceneManager.LoadScene(currentScene.name);
            }
        }
    }

