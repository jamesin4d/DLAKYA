using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Action : ScriptableObject
{
	public abstract void Act (StateController controller);
}

