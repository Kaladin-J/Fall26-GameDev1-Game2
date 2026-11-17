using UnityEngine;

public class Idle : PlayerControllerStates
{
    //State Machine calls this when the state is transitioned into
    public override void Enter(StateMachine stateMachine)
    {
        //Idle Animation
        //***PLACEHOLDER Change Color
        playerCon.rend.material.color = Color.green;
    }

    //State Machine calls this when the state is transitioned out of
    public override void Exit(StateMachine stateMachine)
    {

    }

    //Runs in the StateMachine Update() function
    public override void StateUpdate(StateMachine stateMachine)
    {

    }

    //Runs in the StateMachine FixedUpdate() function
    public override void StateFixedUpdate(StateMachine stateMachine)
    {
        #region Change States

        //Ground State
        if (playerCon.direction != Vector2.zero)
        {
            stateMachine.TransitionStates(stateMachine.states[1]);
            return;
        }

        //Air State
        if (playerCon.jump)
        {
            playerCon.yVel = playerCon.jumpImpulse;
            stateMachine.TransitionStates(stateMachine.states[2]);
            return;
        }

        #endregion
    }
}
