using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class BallStats : MonoBehaviour {
	public int startingDignity = 100;
	public int currentDignity;
	public Slider dignitySlider; // reference to UI slider
	Restarter restarter; // reference to restarter script
	public Image kickedImage; // image shown when kicked. make screen overlay slightly red
	public float flashSpeed = 5f; // speed the image fades at
	public Color flashColor = new Color (1f, 0f, 0f, 0.3f); //color of the image
	bool isDead; // is out of dignity
	bool isKicked; // true when player is kicked

	// Use this for initialization
	void Start () {
		restarter = this.gameObject.AddComponent<Restarter> ();
		//restarter = new Restarter (); // gotta instanciate this 
		currentDignity = startingDignity;

		// if the links haven't been set in this level.
		if(dignitySlider == null) dignitySlider = GameObject.Find("DignitySlider").GetComponent<Slider>();
		if(kickedImage == null) kickedImage = GameObject.Find("kickedImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (isKicked) {
			kickedImage.color = flashColor;
		} 
		else {
			kickedImage.color = Color.Lerp (kickedImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		isKicked = false; //reset kicked flag
	}

	public void loseDignity (int amount)
	{
		isKicked = true;

		currentDignity -= amount; 
		dignitySlider.value = currentDignity;
		if (currentDignity <= 0 && !isDead) {
			Death ();
		}
	}
	void Death() {
		isDead = true;
		restarter.resetActiveScene();
	}
}
