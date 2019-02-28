﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Decision : ScriptableObject
{
	public abstract bool Decide (StateController controller);

}

