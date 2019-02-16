using UnityEngine;
using System.Collections;

public class Kicked : MonoBehaviour {
	//alright getting back into unity. 
	// according to the manual serializeField is used for making editor window ish.
	// so i'm using public variables until i find out otherwise.
    public float kickForce = 10;    
	private void OnCollisionEnter(Collision other){
		if (other.rigidbody)
			other.rigidbody.AddForce(1,5,kickForce, ForceMode.Impulse);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
