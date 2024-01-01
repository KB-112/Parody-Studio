using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class walldetection : MonoBehaviour,IRayDetection
{
    public float rayDistance = 1.0f;
    public LayerMask layerMask;
    public float speed;
  
    public Vector3 distanceThreshold ;
    public Transform player;

   
    public Vector3 rayRotation;
    [SerializeField] private List<GameObject> hitobj = new List<GameObject>();

    Vector3 forwardNoY;
    public void DistanceCheck()
    {
       CheckHitbjPos();
        

    }

  
    void CheckHitbjPos()
    {
        RaycastHit hit;
        Vector3 forwardNoY = player.TransformDirection(rayRotation.normalized);
        if (Physics.Raycast(player.transform.position, forwardNoY, out hit, rayDistance, layerMask))
        {
            Debug.Log("hit");

           
            Transform hitTransform = hit.transform;
            if (hitTransform != null)
            {
                Debug.Log("Transform of the hit object: " + hitTransform.name);
              GameObject find =  GameObject.Find(hitTransform.name);
                hitobj.Add(find);
                Debug.Log("hit point pos" + find.transform.position);
             
             
                MoveObject(hitobj[0].transform.position);
              
            }

            
        }

    }


    private void MoveObject(Vector3 targetPosition)
    {
        StartCoroutine(MovePlayerSmoothly(targetPosition));
    }

    private IEnumerator MovePlayerSmoothly(Vector3 targetPosition)
    {
        while ( player.transform.position != targetPosition )
        {
            float translation = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.position, targetPosition-distanceThreshold, translation);
        
            yield return null;
        }

        Debug.Log("Player reached the target position or movement was stopped.");
    }

    private void OnDrawGizmos()
    {
        Vector3 forward = player.TransformDirection(rayRotation.normalized);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(player.position, player.position + forward * rayDistance);
    }
}
