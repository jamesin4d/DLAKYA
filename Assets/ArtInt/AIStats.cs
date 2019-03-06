using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[CreateAssetMenu (menuName = "ArtInt/AIStats")]
public class AIStats : ScriptableObject
{
	public float moveSpeedMultiplier = 1;
	public float lookRange = 40f;
	public float lookSphereCastRadius = 1f;
	public float kickRange = 1f;
	public float kickRate = 1f;
	public float kickForce = 10f;
	public float kickDamage = 10f;
	public float searchDuration = 4f;


}

