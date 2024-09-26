using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    [SerializeField] private string initSate;
    [SerializeField] private FSMState[] states;
    public FSMState CurrentState { get; set; }
    
    public Transform Player { get; set; }

    private void Start()
    {
        ChangeState(initSate);
    }

    private void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void ChangeState(string stateID)
    {
        FSMState newState = GetState(stateID);
        if (newState == null) return;
        
        CurrentState = newState;

    }

    private FSMState GetState(string stateID)
    {
        for(int i = 0 ; i< states.Length; i++)
        {
            if(states[i].ID == stateID)
            {
                return states[i];
            }
        }
        return null;
    }

}
