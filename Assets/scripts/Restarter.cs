using System;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Restarter : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
				
                SceneManager.LoadScene("sxc");
            }
        }
    }

