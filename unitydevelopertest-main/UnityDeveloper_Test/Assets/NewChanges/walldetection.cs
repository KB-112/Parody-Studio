using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walldetection : MonoBehaviour,IRayDetection
{
    public float rayDistance = 1.0f;
    public LayerMask layerMask;
    public float speed;
  
    public Vector3 distanceThreshold ;
    public Transform player;

   
    public Vector3 rayRotation;
    [SerializeField] private List<GameObject> hitobj = new List<GameObject>();

    private bool isMoving = false;
    
    public void DistanceCheck()
    {
      if (!isMoving)
      {

        
        RaycastHit hit;
        Vector3 forwardNoY = player.TransformDirection(rayRotation.normalized);
            if (Physics.Raycast(player.transform.position, forwardNoY, out hit, rayDistance, layerMask))
            {
                Debug.Log("hit");


                Transform hitTransform = hit.transform;
                if (hitTransform != null)
                {
                    Vector3 worldPosition = hit.point;
                    Vector3 coordinates = new Vector3(worldPosition.x,
                                                      worldPosition.y ,
                                                      worldPosition.z) - new Vector3(distanceThreshold.x,   distanceThreshold.y, distanceThreshold.z); ;

                    // Output the coordinates to the console
                    Debug.Log("Coordinates at " + rayDistance + "m distance: " + coordinates);
                  
                    //---------------------------------------------------------------------------------------
                 
                     //  MoveObject(coordinates );

                    


                }

            }
        }


    }

  

    private void MoveObject(Vector3 targetPosition)
    {
        StartCoroutine(MovePlayerSmoothly(targetPosition));
    }

    private IEnumerator MovePlayerSmoothly(Vector3 targetPosition)
    {
        isMoving = true;
        while ( player.transform.position != targetPosition )
        {
            float translation = speed * Time.deltaTime;
           player.transform.position = Vector3.MoveTowards(player.position, targetPosition , translation);
            

            yield return null;
        }
        isMoving = false;
        Debug.Log("Player reached the target position or movement was stopped.");
      
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = player.TransformDirection(rayRotation.normalized);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(player.position, player.position + forward * rayDistance);
    }
}
