using UnityEngine;
using System.Collections;

public class Kicked : MonoBehaviour {
	
    [SerializeField] private float kickForce = 10;    
	private void OnCollisionEnter(Collision other){
		if (other.rigidbody)
			other.rigidbody.AddForce(1,5,kickForce, ForceMode.Impulse);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
