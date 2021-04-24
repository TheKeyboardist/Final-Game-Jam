using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTile : MonoBehaviour
{
    GameObject playerRef;
    PlayerController scriptRef;

    public int stepLength;
    public Vector3 size;
    private void Awake()
    {

        stepLength = 3;
        size = new Vector3(1.5f, 1.5f, 1.5f);
        playerRef = GameObject.FindGameObjectWithTag("Player");
        scriptRef = playerRef.GetComponent<PlayerController>();
    }

    public void ApplyEffect()
    {
        scriptRef.stepLength = stepLength;
        playerRef.transform.localScale = size;
    }
}
