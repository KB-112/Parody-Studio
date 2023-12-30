
using UnityEngine;
using System.Collections;


public class PlayerJumpEffect : MonoBehaviour
{

    [SerializeField] private LayerMask collisionLayer; // Layer to detect collisions with

    public GameObject playerPosition;
    private float totalDistanceCovered = 0f;
    [SerializeField] public float maxDistance = 50f;


    public Vector3 boxSize = new Vector3(1, 1, 1);
    public float jumpHeight;
    public float jumpSpeed;
    float jumpDistance = 5.0f;
    IJumpAnim jumpAnim;
    IKeyboardCntrlNone keyboardCntrlNone;
    public IGameOver gameOver;
    bool isJumping = false;
    void Start()
    {
        jumpAnim = GetComponent<IJumpAnim>();
        keyboardCntrlNone = GetComponent<IKeyboardCntrlNone>();
       gameOver = GetComponent<IGameOver>();  
    }
    void Update()
    {
        DetectCollision();
        
    }

    void DetectCollision()
    {
        Collider[] colliders = Physics.OverlapBox(playerPosition.transform.position, boxSize / 2f, Quaternion.identity, collisionLayer);

        if (colliders.Length > 0)
        {

            foreach (Collider col in colliders)
            {
                JumpEffect();

                Debug.Log("Collider detected: " + col.gameObject.name);
             
            }
        }
        else
        {
            keyboardCntrlNone.IdlePlayer();
            MaxDistance();
            DistanceCover();
        }


    }

    void DistanceCover()
    {
        float distanceThisFrame = 10 * Time.deltaTime;
        PlayerMovement.instance.spaceBoy.Translate(Vector3.down * distanceThisFrame);


        totalDistanceCovered += distanceThisFrame;
        jumpAnim.Jump();
        gameOver.GameOver();


    }


    public void MaxDistance()
    {
        if (totalDistanceCovered >= maxDistance)
        {
            Debug.Log("Free Fall");
            Debug.Log("Maximum distance reached!");
            

        }



    }

    private void OnDrawGizmos()
    {

        Gizmos.DrawWireCube(playerPosition.transform.position, boxSize);
    }

    void JumpEffect()
    {


        
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                isJumping = true;
         //   jumpAnim.Jump();
            StartCoroutine(PlayerJump());
            }

            if (Input.GetKeyDown(KeyCode.Space)&& Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                isJumping = true;
            if (isJumping)
            {
                jumpAnim.Jump();
            }
            StartCoroutine(JumpForward());
            }
        


    }
    IEnumerator PlayerJump()
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

    IEnumerator JumpForward()
    {
        Vector3 startPos = playerPosition.transform.position;
        Vector3 endPos = startPos + playerPosition.transform.forward * jumpDistance;
        float timeElapsed = 0;

        while (timeElapsed < 1.0f)
        {
            timeElapsed += Time.deltaTime * jumpSpeed;
            playerPosition.transform.position = Vector3.Lerp(startPos, endPos, timeElapsed);

            yield return null;
        }

        isJumping = false;
    }



}
