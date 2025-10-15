using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float vertSpeed;
    private float sideInput;
    private float vertInput;
    public bool isSliding;

    private Rigidbody2D PRB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //testing Gamemanager
        //Debug.Log(GameManager.instance.getScore());

        PRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //lateralMovement();
        //verticalMovement();
        GameManager.instance.updateStats();
        movement();
        otherButtons();
    }


    private void otherButtons()
    {
        if(Input.GetKeyDown(KeyCode.Q) && GameManager.instance.getPotion() && GameManager.instance.getHP() < 3)
        {
            GameManager.instance.potionAbility();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.pause();
        }

    }

    private void movement()
    {
        sideInput = Input.GetAxisRaw("Horizontal");
        vertInput = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(sideInput *moveSpeed, vertInput * vertSpeed, 0);
        PRB.linearVelocity = direction;
    }

    //=========================================================================
    //The method below was harder to try and get to work than the method above
    //=========================================================================

    //private void lateralMovement()
    //{
    //    sideInput = Input.GetAxisRaw("Horizontal");
    //    PRB.linearVelocity = new Vector2 (moveSpeed * sideInput, PRB.linearVelocityY);
    //}
    //private void verticalMovement()
    //{
    //    vertInput = Input.GetAxisRaw("Vertical");
    //    PRB.linearVelocity = new Vector2(vertSpeed * vertInput, PRB.linearVelocityX);
    //}




}
