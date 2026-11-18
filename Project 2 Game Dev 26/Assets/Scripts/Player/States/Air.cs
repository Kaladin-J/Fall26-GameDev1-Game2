using UnityEngine;

public class Air : PlayerControllerStates
{
    //State Machine calls this when the state is transitioned into
    public override void Enter(StateMachine stateMachine)
    {
        //Jump Animation
        //***PLACEHOLDER Change Color
        playerCon.rend.material.color = Color.yellow;
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
        //Gravity
        playerCon.yVel -= playerCon.gravity * Time.fixedDeltaTime;

        //Construct Velocity
        playerCon.xzVel = playerCon.direction * playerCon.speed * Time.fixedDeltaTime;
        playerCon.velocity = new Vector3(playerCon.xzVel.x, playerCon.yVel, playerCon.xzVel.y);

        //Move
        playerCon.controller.Move(playerCon.velocity * Time.fixedDeltaTime);

        #region Change State

        //Grond & Idle
        if (playerCon.controller.isGrounded)
        {
            if (playerCon.xzVel == Vector2.zero)
                stateMachine.TransitionStates(stateMachine.states[0]);
            else
                stateMachine.TransitionStates(stateMachine.states[1]);
        }

        #endregion
    }
}
