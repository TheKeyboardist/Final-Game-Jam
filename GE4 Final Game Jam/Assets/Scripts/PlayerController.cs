using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
   // PlayerInput input;
    private PlayerActions playerActionsControls;
    public int stepLength;
    public Vector3 currentPosition;
    public Vector3 nextPosition;
    public bool animPlayed;


    private void Awake()
    {
        // input = new PlayerInput();
        playerActionsControls = new PlayerActions();
    }


    private void OnEnable()
    {
        playerActionsControls.Enable();
    }

    private void OnDisable()
    {
        playerActionsControls.Disable();
    }



    void Start()
    {
        stepLength = 2;
        animPlayed = true;
        currentPosition = transform.position;
        playerActionsControls.CharacterControls.Movement.performed += ctx => Move(playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>());

    }

    void Update()
    {
        Debug.Log(playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>());
    }

    public void Move(Vector2 direction)
    {
        float x = transform.position.x + playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>().x * stepLength;
        float y = transform.position.z + playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>().y * stepLength;
        nextPosition = new Vector3(x, transform.position.y, y);
        transform.position = nextPosition;
    } 

}
