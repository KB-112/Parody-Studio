using Unity.VisualScripting;
using UnityEngine;

public class walldetection : MonoBehaviour
{
    public float rayDistance = 1.0f;
    public LayerMask layerMask;
    public float speed;
    bool stop = false;
    public float distanceThreshold = 2.0f;
    public Transform player;
    public float nearwall;
    float distance;
    private void Update()
    {
        MoveObjectDown();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            distance = Vector3.Distance(player.position, transform.position);
            stop = true;


        }
    }


    private void MoveObjectDown()
    {
        if (stop)
        {
            float translation = speed * Time.deltaTime;
            transform.Translate(Vector3.down * translation);

         
            Vector3 raycastDirection = -player.forward; 

            RaycastHit hit;
            if (Physics.Raycast(transform.position, raycastDirection, out hit, rayDistance, layerMask))
            {
                float distanceToHitPoint = hit.point.y - transform.position.y;

                if (distanceToHitPoint <= 0.1f)
                {
                    speed = Mathf.Lerp(1f, speed, distance / speed);
                    stop = false;
                }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayDistance);
    }
}
