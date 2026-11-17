using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
# region Input Actions
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction dodgeAction;
    private InputAction attackAction;

    #endregion

# region Components
    [HideInInspector] public CharacterController controller;
    [HideInInspector] public MeshRenderer rend;
    #endregion

# region Movement
    public float speed = 250f;
    [HideInInspector] public Vector2 direction = Vector2.zero;
    [HideInInspector] public Vector2 xzVel = Vector2.zero;
    [HideInInspector] public float yVel = 0;
    [HideInInspector] public Vector3 velocity = Vector3.zero;
    #endregion

# region Forces
    public float jumpImpulse = 7.5f;
    public float gravity = 9.81f; //Gravity is always positive
    #endregion

    //Jumping
    [HideInInspector] public bool jump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Inputs
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        dodgeAction = InputSystem.actions.FindAction("Dodge");
        attackAction = InputSystem.actions.FindAction("Attack");

        //Components
        controller = GetComponent<CharacterController>();
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();
        jump = jumpAction.IsPressed();
    }
}
