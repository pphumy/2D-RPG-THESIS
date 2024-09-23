using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMDecision : MonoBehaviour
{
    // Start is called before the first frame update
    public abstract bool Decide();
}
