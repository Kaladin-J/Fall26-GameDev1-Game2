using UnityEngine;

public class PlayerControllerStates : States
{
    protected PlayerController playerCon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Change from "Temp Player" to "Player"
        playerCon = GameObject.Find("Temp Player").GetComponent<PlayerController>();
    }
}
