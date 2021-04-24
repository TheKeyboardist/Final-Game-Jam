using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTile : MonoBehaviour
{
    GameObject playerRef;
    PlayerController scriptRef;

    public int stepLength;
    public Vector3 size;
    private void Awake()
    {
        stepLength = 1;
        size = new Vector3(0.5f, 0.5f, 0.5f);
        playerRef = GameObject.FindGameObjectWithTag("Player");
        scriptRef = playerRef.GetComponent<PlayerController>();
    }


    public void ApplyEffect()
    {
        scriptRef.stepLength = stepLength;
        playerRef.transform.localScale = size;
    }
}
