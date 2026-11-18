using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //Current State
    private States currentState;

    //Array of States
    public States[] states;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Start in Idle State
        currentState = states[0];

        //Enter the idle state
        currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.StateUpdate(this);
    }

    private void FixedUpdate()
    {
        currentState.StateFixedUpdate(this);
    }

    public void TransitionStates(States newState)
    {
        //Exit old state
        currentState.Exit(this);
        //Get new state
        currentState = newState;
        //Enter new state
        currentState.Enter(this);
    }
}
