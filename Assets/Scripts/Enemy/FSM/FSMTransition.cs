using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FSMTransition
{
    // Start is called before the first frame update
    public FSMDecision Decision;
    public string  TrueState;
    public string  FalseState;
}
