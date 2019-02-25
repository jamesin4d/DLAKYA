﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

	[Tooltip("Amount of force to apply to the player.")]
	[Range(1,50)]
	public float launchForce = 10;

	[Tooltip("The direction to launch the player.")]
	public Vector3 launchDirection = Vector3.up;

	[Tooltip("If this object can be moved through, it is a funnel. Ignores launchDirection and shoots backwards.")]
	public bool isFunnel = false;

	void Start() {
		if (isFunnel) {
			launchDirection = this.transform.forward;
		}
	}


	void OnTriggerEnter(Collider other) {
		if(other.gameObject.CompareTag("Player")) {
			Rigidbody rb = other.GetComponent<Rigidbody>();
			if(rb != null) {
				rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
			}
		}
	}
}