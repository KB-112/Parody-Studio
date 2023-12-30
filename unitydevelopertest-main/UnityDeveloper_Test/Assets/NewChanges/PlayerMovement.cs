
using UnityEngine;


public class PlayerMovement :MonoBehaviour, IKeyboardCntrl, IKeyboardCntrlNone
{
    public Transform spaceBoy;
     float moveSpeed = 0;
    public float runningspeed =0;
    public float rotateSpeed = 0;

    public float jumpHeight = 2f;

    public static PlayerMovement instance;
    IKeyboardCntrlNone keyboardCntrlNone;
    IKeyboardCntrl keyboardCntrl;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
         keyboardCntrlNone = GetComponent<IKeyboardCntrlNone>();
        keyboardCntrl = GetComponent<IKeyboardCntrl>();
    }
    void Update()
    {   MoveForward();
        MoveBackward();
        MoveLeft();
       MoveRight();
        IdlePlayer();
       

    }

    
    public void MoveForward()
    {
        if (Input.GetKey(KeyCode.W) )
        {         
            spaceBoy.Translate(Vector3.forward * moveSpeed *runningspeed* Time.deltaTime);

            keyboardCntrl.MoveForward();
        }
    }

    public void MoveBackward()
    {
        if (Input.GetKey(KeyCode.S))
        {
            spaceBoy.Translate(Vector3.back * moveSpeed *runningspeed* Time.deltaTime);
            keyboardCntrl.MoveBackward();
        }
    }

    public void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            spaceBoy.Rotate(Vector3.down, rotateSpeed * 10 * Time.deltaTime);
            keyboardCntrl.MoveLeft();
        }
    }

    public void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            spaceBoy.Rotate(Vector3.up, rotateSpeed * 10 * Time.deltaTime);
            keyboardCntrl.MoveRight();
        }
    }

    public void IdlePlayer()
    {
        if (!Input.anyKey)
        {
            moveSpeed = 0;
            keyboardCntrlNone.IdlePlayer();


        }
        else
        {
            moveSpeed = 1;
        }
    }

    

    }
