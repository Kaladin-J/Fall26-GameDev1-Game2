using UnityEngine;

public class Ground : PlayerControllerStates
{
    //State Machine calls this when the state is transitioned into
    public override void Enter(StateMachine stateMachine)
    {
        //Walk Animation
        //***PLACEHOLDER Change Color
        playerCon.rend.material.color = Color.blue;
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
        //Construct Velocity
        playerCon.xzVel = playerCon.direction * playerCon.speed * Time.fixedDeltaTime;
        playerCon.velocity = new Vector3(playerCon.xzVel.x, -playerCon.gravity, playerCon.xzVel.y);

        //Move
        playerCon.controller.Move(playerCon.velocity * Time.fixedDeltaTime);

        #region Change States

        //Idle State
        if (playerCon.controller.velocity == Vector3.zero)
        {
            if (playerCon.direction == Vector2.zero)
            {
                stateMachine.TransitionStates(stateMachine.states[0]);
                return;
            }
        }

        //Air State
        if (playerCon.jump && playerCon.controller.isGrounded)
        {
            playerCon.yVel = playerCon.jumpImpulse;
            stateMachine.TransitionStates(stateMachine.states[2]);
            return;
        }

        if (!playerCon.controller.isGrounded)
        {
            stateMachine.TransitionStates(stateMachine.states[2]);
            return;
        }

        #endregion
    }
}
