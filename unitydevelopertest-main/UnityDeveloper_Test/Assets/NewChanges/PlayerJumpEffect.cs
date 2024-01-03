using UnityEngine;
using System.Collections;

public class PlayerJumpEffect : MonoBehaviour
{
    [SerializeField] private LayerMask collisionLayer; // Layer to detect collisions with

    public Transform playerPosition;
    public Vector3 rayRotation;
    public float rayDistance;
  

    public float jumpHeight;
    public float jumpSpeed;
    public float jumpDistance = 5.0f;

    private IJumpAnim jumpAnim;
    private IKeyboardCntrlNone keyboardCntrlNone;
    private IGameOver gameOver;
    IMidAir midAir;
    private bool isJumping = false;

    private void Start()
    {
        InitializeComponents();
    }

    private void Update()
    {
        DetectCollision();
    }

    private void InitializeComponents()
    {
        jumpAnim = GetComponent<IJumpAnim>();
        keyboardCntrlNone = GetComponent<IKeyboardCntrlNone>();
        gameOver = GetComponent<IGameOver>();
        midAir = GetComponent<IMidAir>();
    }

    private void DetectCollision()
    {
        RaycastHit hit;
        Vector3 forwardNoY = playerPosition.TransformDirection(rayRotation.normalized);
        if (Physics.Raycast(playerPosition.position, forwardNoY, out hit, rayDistance, collisionLayer))
        {
            JumpEffect();
            midAir.StopJumpAnim();
            Debug.Log("hit wall by magenta raycast");
        }
        else
        {
            jumpAnim?.Jump();
            midAir.AnimationJump();
            DistanceCover();
        }
    }

    private void DistanceCover()
    {
        float distanceThisFrame = 10 * Time.deltaTime;
        PlayerMovement.instance.spaceBoy.Translate(Vector3.down * distanceThisFrame);
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = playerPosition.TransformDirection(rayRotation.normalized);
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(playerPosition.position, playerPosition.position + forward * rayDistance);
    }

    private void JumpEffect()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(Input.GetKeyDown(KeyCode.W) ? JumpForward() : PlayerJump());
        }
    }

    public void AnimationJump(bool jump)
    {
        
       
    }

    private IEnumerator PlayerJump()
    {
        float startY = playerPosition.transform.position.y;
        float timeElapsed = 0;

        while (timeElapsed < 1.0f)
        {
            timeElapsed += Time.deltaTime * jumpSpeed;
            float newY = Mathf.Lerp(startY, startY + jumpHeight, timeElapsed);
            playerPosition.transform.position = new Vector3(
                playerPosition.transform.position.x,
                newY,
                playerPosition.transform.position.z);

            yield return null;
        }

        isJumping = false;
    }

    private IEnumerator JumpForward()
    {
        Vector3 startPos = playerPosition.transform.position;
        Vector3 endPos = startPos + playerPosition.transform.forward * jumpDistance;
        float timeElapsed = 0;

        while (timeElapsed < 1.0f)
        {
            keyboardCntrlNone?.IdlePlayer();
            timeElapsed += Time.deltaTime * jumpSpeed;
            playerPosition.transform.position = Vector3.Lerp(startPos, endPos, timeElapsed);

            yield return null;
        }

        isJumping = false;
    }
}
