using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject moveCounter_GO;
    
    Text moveCounter_Text;

    [SerializeField]
    public int movesLeft;
    void Awake()
    {
        moveCounter_Text = moveCounter_GO.GetComponent<Text>();
    }

    private void Start()
    {
        movesLeft = 25;
        
    }


    private void Update()
    {
        moveCounter_Text.text = "Moves left: "  + movesLeft.ToString();
    }

}
