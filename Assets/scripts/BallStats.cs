﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BallStats : MonoBehaviour {
	public int startingDignity = 100;
	public int currentDignity;
	public Slider dignitySlider; // reference to UI slider
	Restarter restarter; // reference to restarter script
	public Image kickedImage; // image shown when kicked. make screen overlay slightly red
	public float flashSpeed = 5f; // speed the image fades at
	public Color flashColor = new Color (1f, 0f, 0f, 0.1f); //color of the image
	bool isDead; // is out of dignity
	bool kicked; // true when player is kicked

	// Use this for initialization
	void Start () {
		restarter = GetComponent <Restarter> ();
		currentDignity = startingDignity;
	}
	
	// Update is called once per frame
	void Update () {
		if (kicked) {
			kickedImage.color = flashColor;
		} 
		else {
			kickedImage.color = Color.Lerp (kickedImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		kicked = false; //reset kicked flag
	}

	public void loseDignity (int amount)
	{
		Kicked = true;
		currentDignity -= amount; 
		dignitySlider.value = currentDignity;
		if (currentDignity <= 0 && !isDead) {
			Death ();
		}
	}
	void Death() {
		isDead = true;
		restarter.resetActiveScene ();
	}
}
