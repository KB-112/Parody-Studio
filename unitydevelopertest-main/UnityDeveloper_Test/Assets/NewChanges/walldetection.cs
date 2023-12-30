using Unity.VisualScripting;
using UnityEngine;

public class walldetection : MonoBehaviour,IRayDetection
{
    public float rayDistance = 1.0f;
    public LayerMask layerMask;
    public float speed;
    bool stop = false;
    public float distanceThreshold = 2.0f;
    public Transform player;
    public float nearwall;
    float distance;
    public Vector3 rayRotation;

    private void Update()
    {
        MoveObjectDown();
      
    }

    public void DistanceCheck()
    {
        RaycastHit hit;
        Vector3 forwardNoY = Quaternion.Euler(rayRotation) * Vector3.forward;
        stop = true;
        if (Physics.Raycast(player.transform.position, forwardNoY, out hit, rayDistance, layerMask))
        {
            Debug.Log("hit");

            float distanceY = Mathf.Abs(player.transform.position.y - hit.point.y);
            Debug.Log("distance" + distanceY);

            if (distanceY <= distanceThreshold)
            {
                stop = false;
                Debug.Log("on stop distance" + distanceY);
            }
        }
    }

  
    private void MoveObjectDown()
    {
        if (stop)
        {
            float translation = speed * Time.deltaTime;
            player.transform.Translate(Vector3.down * translation);


           
        }
        RaycastHit hit;
        Vector3 forwardNoY = Quaternion.Euler(rayRotation) * Vector3.forward;
        if (Physics.Raycast(player.transform.position, forwardNoY, out hit, rayDistance, layerMask))
            {
                Debug.Log("hit");

                float distanceY = Mathf.Abs(player.transform.position.y - hit.point.y);
                Debug.Log("distance" + distanceY);

                if (distanceY <= distanceThreshold)
                {
                    stop = false;
                    Debug.Log("on stop distance" + distanceY);
                }
            }
        
        
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Quaternion.Euler(rayRotation) * Vector3.forward * rayDistance);
    }
}
