using UnityEngine;
using System.Collections;

namespace AIPerson 
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	public class AIPersonCharacter : MonoBehaviour
	{
		public float movingTurnSpeed = 360;
		public float stationaryTurnSpeed = 180;
		public float jumpSpeed = 12f;
		[Range(1f,4f)]public float gravityMultiplier = 2f;
		public float moveSpeedMultiplier = 1f;
		public float groundCheckDistance = 0.1f;
	
		Rigidbody rigBody;
		bool isGrounded;
		float origGroundCheckDist;
		const float k_half = 0.5f;
		float turnAmount;
		float forwardAmount;
		Vector3 groundNormal;
		float capsuleHeight;
		Vector3 capsuleCenter;
		CapsuleCollider capsule;

		// Use this for initialization

		void Start ()
		{
			rigBody = GetComponent<Rigidbody> ();
			capsule = GetComponent<CapsuleCollider> ();
			capsuleHeight = capsule.height;
			capsuleCenter = capsule.center;
			rigBody.constraints = RigidbodyConstraints.FreezeRotationX |RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			origGroundCheckDist = groundCheckDistance;
		}
	
		public void Move(Vector3 move, bool jump)
		{
			if (move.magnitude > 1f)
				move.Normalize ();
			move = transform.InverseTransformDirection (move);
			CheckGround ();
			move = Vector3.ProjectOnPlane (move, groundNormal);
			turnAmount = Mathf.Atan2 (move.x, move.z);
			forwardAmount = move.z;
			ApplyExtraTurn ();
			if (isGrounded) {
				GroundMovement (jump);
			} else {
				AirMovement ();
			}
		}

		void AirMovement()
		{	
			Vector3 extraGravity = (Physics.gravity * gravityMultiplier) - Physics.gravity;
			rigBody.AddForce (extraGravity);
			groundCheckDistance = rigBody.velocity.y < 0 ? origGroundCheckDist : 0.01f;
		}

		void GroundMovement(bool jump)
		{	
			if (jump) {
				rigBody.velocity = new Vector3 (rigBody.velocity.x, jumpSpeed, rigBody.velocity.z);
				isGrounded = false;
				groundCheckDistance = 0.1f;

			}
		}

		void ApplyExtraTurn()
		{
			float turn = Mathf.Lerp (stationaryTurnSpeed, movingTurnSpeed, forwardAmount);
			transform.Rotate (0, turnAmount * turn * Time.deltaTime, 0);
		}

		void CheckGround()
		{	
			RaycastHit hit;
			if (Physics.Raycast (transform.position + (Vector3.up * 0.1f), Vector3.down, out hit, groundCheckDistance)) {
				groundNormal = hit.normal;
				isGrounded = true; 
				// stay in your room
			} else {
				isGrounded = false;
				groundNormal = Vector3.up;
			}
		}
		// Update is called once per frame
		void Update ()
		{
		
		}
	}
}
