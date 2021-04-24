using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    GameObject playerRef;
    PlayerController playerScriptRef;
    public GameObject moveCounter_GO;
    public GameObject gameOverPanel_GO;
    public GameObject startPanel_GO;
    public GameObject endPhrase_GO;
    Text endPhrase_Text;
    Text moveCounter_Text;
    
    public bool gameWon;
    
    [SerializeField]
    public int movesLeft;
    void Awake()
    {
        playerRef = GameObject.Find("Player");
        playerScriptRef = playerRef.GetComponent<PlayerController>();
        endPhrase_Text = endPhrase_GO.GetComponent<Text>();
        gameWon = false;
        moveCounter_Text = moveCounter_GO.GetComponent<Text>();
        gameOverPanel_GO.SetActive(false);
        startPanel_GO.SetActive(true);
    }

    private void Start()
    {
        movesLeft = 25;

    }


    private void Update()
    {
        if(playerScriptRef.animFinished || playerScriptRef == null)
        {
            startPanel_GO.SetActive(false);
        }


        
        moveCounter_Text.text = "Moves left: "  + movesLeft.ToString();
        if(gameWon && movesLeft > 0 || gameWon)
        {
            gameOverPanel_GO.SetActive(true);
            endPhrase_Text.text = "You Win! Congrats!!";
        }
        else if(!gameWon && movesLeft < 1)
        {
            gameOverPanel_GO.SetActive(true);
            endPhrase_Text.text = "You Lose! Try Again!!";
        }
    }

}
