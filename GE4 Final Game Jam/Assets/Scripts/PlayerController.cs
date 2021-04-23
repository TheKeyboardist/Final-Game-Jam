using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
   // PlayerInput input;
    PlayerActions controls;
    public int stepLength;
    public Vector3 currentPosition;
    public Vector3 nextPosition;
    public bool animPlayed;


    private void Awake()
    {
        // input = new PlayerInput();
        
    }

    void Start()
    {
        stepLength = 2;
        animPlayed = true;
        currentPosition = transform.position;

    }

    void Update()
    {
        float x = transform.position.x + controls.CharacterControls.Movement.ReadValue<Vector2>().x * stepLength;
        float y = transform.position.z + controls.CharacterControls.Movement.ReadValue<Vector2>().y * stepLength;
        nextPosition = new Vector3(x, transform.position.y, y);
       // Debug.Log(controls.CharacterControls.Movement.ReadValue<Vector2>());
    }

    public void Move()
    {
       // transform.position.x += controls.CharacterControls.Movement.ReadValue<Vector2>().x;
        float x = transform.position.x + controls.CharacterControls.Movement.ReadValue<Vector2>().x * stepLength;
        float y = transform.position.z + controls.CharacterControls.Movement.ReadValue<Vector2>().y * stepLength;
        nextPosition = new Vector3(x, transform.position.y, y);
    }

}
