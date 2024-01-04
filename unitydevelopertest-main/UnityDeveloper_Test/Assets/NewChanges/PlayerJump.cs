using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerJump : MonoBehaviour
{


    [SerializeField] private LayerMask collisionLayer;

    public Transform playerPosition;
    public Vector3 rayRotation;
    public float[] rayDistance;

    public float jumpHeight;
    public float jumpSpeed;
    public float jumpDistance = 5.0f;
    private IJumpAnim jumpAnim;
    private IKeyboardCntrlNone keyboardCntrlNone;
    private IGameOver gameOver;
    IMidAir midAir;
    IRayDetection rayDetection;
    private bool isJumping = false;

    bool floorDetect = false;
    float rayLength;
    bool isMoving =false;
  
    private void Start()
    {
        InitializeComponents();
    }

    private void Update()
    {
        DetectCollision();
    }

    
    private void DetectCollision()
    {if(!isMoving)
        {
            rayLength = rayDistance[0];
        }
        if (rayDetection.DistanceCheck())
        {
            rayLength = rayDistance[1];
            isMoving = true;
           
        }
           
   
         RaycastHit hit;
        Vector3 forwardNoY = playerPosition.TransformDirection(rayRotation.normalized);
        if (Physics.Raycast(playerPosition.position, forwardNoY, out hit, rayLength, collisionLayer))
        {
            
            midAir.StopJumpAnim();           
            MovePlayerSmoothly(FindCoordinate(hit.point));
            floorDetect = false;
          
        }
        else
        {
            jumpAnim?.Jump();
            midAir.AnimationJump();
            floorDetect = true;
            MovePlayerSmoothly(FindCoordinate(hit.point));

        }
    }

    private Vector3 FindCoordinate(Vector3 hitTransform )
    {
     
            Vector3 worldPosition = hitTransform;
            Debug.Log("world coordiates :" +worldPosition);

            return worldPosition;

        
     }

    private void MovePlayerSmoothly(Vector3 targetPosition)

    {
        if (isMoving )
        {
            float distance = Vector3.Distance(playerPosition.transform.position, targetPosition);
            float translation = jumpSpeed * Time.deltaTime;

            if (distance > 0.001f) 
            {
                playerPosition.transform.position = Vector3.MoveTowards(playerPosition.position, targetPosition, translation);
            }
            else
            {
                isMoving = false;
                Debug.Log("Player reached the target position or movement was stopped.");
            }
        }
    }

   
    private void InitializeComponents()
    {
        jumpAnim = GetComponent<IJumpAnim>();
        keyboardCntrlNone = GetComponent<IKeyboardCntrlNone>();
        gameOver = GetComponent<IGameOver>();
        midAir = GetComponent<IMidAir>();
        rayDetection = GetComponent<IRayDetection>();
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = playerPosition.TransformDirection(rayRotation.normalized);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(playerPosition.position, playerPosition.position + forward * rayLength);
    }





}
