using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    public int stepLength;
    public Vector3 currentPosition;
    public Vector3 nextPosition;
    public bool animPlayed;


    void Start()
    {
        stepLength = 2;
        animPlayed = true;
        currentPosition = transform.position;

    }

    void Update()
    {
        
    }

    public void Move()
    {

    }

}
