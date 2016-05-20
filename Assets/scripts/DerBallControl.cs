using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


namespace UnityStandardAssets.Vehicles.Ball {

	public class DerBallControl : MonoBehaviour {
		private Ball ball;
		private Vector3 move;
		private Transform cam;
		private Vector3 camForward;
		private bool jump;
		
		private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();


            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found.");
            }
        }
		
	
	// Update is called once per frame
		void Update () {
			float h = CrossPlatformInputManager.GetAxis("BallHorizontal");
            float v = CrossPlatformInputManager.GetAxis("BallVertical");
			
            jump = CrossPlatformInputManager.GetButton("Jump");
			

            // calculate move direction
            if (cam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v*camForward + h*cam.right).normalized;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (v*Vector3.forward + h*Vector3.right).normalized;
				
            }
	
		}
		
		private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move, jump);
            jump = false;
        }
	}

}
