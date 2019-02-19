using UnityEngine;
using System.Collections;

public class JerkAttack : MonoBehaviour
{
	public float timeBetweenKicks = 0.7f;
	public int kickDamage = 10;
	public int kickForce = 10;
	GameObject player;
	BallStats ballStats;
	bool playerInRange;
	float timer;
	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		ballStats = player.GetComponent <BallStats> ();
	}

	void OnCollisionEnter(Collision other)
	{
		//if (other.GetComponent<Rigidbody>()){
		//	other.GetComponent<Rigidbody>().AddForce(1,5,kickForce, ForceMode.Impulse);
		//}
		if (other.gameObject == player) {
			playerInRange = true;
			Debug.Log ("collision enter");

		}
	}



	void OnCollisionExit(Collision other){

		if (other.gameObject == player) {
			playerInRange = false;
			Debug.Log ("collision exit");
		}
	}

	void Kick(){
		timer = 0f;
		Debug.Log ("being kicked");
		if (ballStats.currentDignity > 0) {
			ballStats.loseDignity (kickDamage);
		}
		if (player.GetComponent<Rigidbody> ()) {
			player.GetComponent<Rigidbody>().AddForce(1,5,kickForce, ForceMode.Impulse);

		}
		playerInRange = false;


	}

	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log (playerInRange);
		timer += Time.deltaTime;
		if(timer >= timeBetweenKicks && playerInRange && ballStats.currentDignity>0)
		{ 
			Kick ();
		}
	
	}
}

