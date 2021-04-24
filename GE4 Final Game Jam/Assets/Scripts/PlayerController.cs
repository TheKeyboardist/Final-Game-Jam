using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    GameObject gameManager_GO_Ref;
    GameManager gameManager_S_Ref;

    public Animator animator;

    private PlayerActions playerActionsControls;
    public int stepLength;
    public Vector3 newCurrentPosition;
    public Vector3 nextPosition;
    public bool animFinished;




    private void Awake()
    {
        gameManager_GO_Ref = GameObject.FindGameObjectWithTag("GameManager");
        gameManager_S_Ref = gameManager_GO_Ref.GetComponent<GameManager>();
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
        animFinished = false;
        newCurrentPosition = transform.position;
        playerActionsControls.CharacterControls.Movement.performed += ctx => Move(playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>());
        animator.SetTrigger("IntroTrigger");
        StartCoroutine(DelayStart());
        if(animFinished)
        StopCoroutine(DelayStart());
    }

    void Update()
    {
    }

    public void Move(Vector2 direction)
    {
        if(animFinished && gameManager_S_Ref.movesLeft > 0)
        {
            float x = transform.position.x + playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>().x * stepLength;
            float y = transform.position.z + playerActionsControls.CharacterControls.Movement.ReadValue<Vector2>().y * stepLength;
            nextPosition = new Vector3(x, transform.position.y, y);
            Debug.Log("trying to move");
            if (CanMove(direction))
            {
                transform.position = nextPosition;
                UpdateStats();
            }
            gameManager_S_Ref.movesLeft--;
        }
       
    } 

    private bool CanMove(Vector2 direction)
    {
        if (gameManager_S_Ref.movesLeft < 1)
        {
            return false;
        }
        nextPosition = new Vector3(transform.position.x + direction.x*stepLength, transform.position.y, transform.position.z + direction.y*stepLength);
        RaycastHit hit;

        if (Physics.Raycast(nextPosition, Vector3.down, out hit) && hit.transform.parent.tag == "Tile")
        {
            return true;
        }
        else return false;
    }

    private void UpdateStats()
    {
        BringStockStats();
        RaycastHit hit;
        //finding the tile standing on
        if (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.collider != transform.root.gameObject.GetComponent<Collider>() && hit.transform.parent.tag == "Tile")
        {
            //accessing tile's informtion
            if (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.tag == "Pink")
            {
                //changing backend parameters
                PinkTile scriptRef = hit.transform.GetComponent<PinkTile>();
                scriptRef.ApplyEffect();
            }
            if (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.tag == "Red")
            {
                //changing backend parameter
                RedTile scriptRef = hit.transform.GetComponent<RedTile>();
                scriptRef.ApplyEffect();
            }
            if (Physics.Raycast(transform.position, Vector3.down, out hit) && hit.transform.tag == "FinishTag")
            {
                animFinished = false;
                animator.GetComponent<Animator>().enabled = true;
                animator.SetTrigger("OutroTrigger");
                StartCoroutine(DelayEnd());
            }

                //changing frontend parameters
                transform.Find("Top").GetComponent<Renderer>().material = hit.transform.GetComponent<Renderer>().material;
        }

    }

    private void BringStockStats()
    {
        stepLength = 2;
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }


    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(3.0f);

        animator.GetComponent<Animator>().enabled = false;
        animFinished = true;
    }

    IEnumerator DelayEnd()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
        gameManager_S_Ref.gameWon = true;
    }
}
