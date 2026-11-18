using UnityEngine;

public class States : MonoBehaviour
{
    //State Machine calls this when the state is transitioned into
    public virtual void Enter(StateMachine stateMachine)
    {

    }

    //State Machine calls this when the state is transitioned out of
    public virtual void Exit(StateMachine stateMachine)
    {

    }

    //Runs in the StateMachine Update() function
    public virtual void StateUpdate(StateMachine stateMachine)
    {

    }

    //Runs in the StateMachine FixedUpdate() function
    public virtual void StateFixedUpdate(StateMachine stateMachine)
    {

    }
}
