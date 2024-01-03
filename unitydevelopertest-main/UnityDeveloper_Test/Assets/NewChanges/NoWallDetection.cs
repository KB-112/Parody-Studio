using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWallDetection : MonoBehaviour
{
    public Transform[] player;
    public Vector3 rayRotation;
    public float rayDistance;
    public float speed;

    public LayerMask floorMask;
  
    private void Update()
    {
        
        CheckHitPos();
        

    }

    void CheckHitPos()
    {

        RaycastHit hit;
        Vector3 forwardNoY = player[0].TransformDirection(rayRotation.normalized);

        if (Physics.Raycast(player[0].position, forwardNoY, out hit, rayDistance,floorMask))
        {


        }
        else
        {
            Debug.Log("Hit empty space");
            player[0].transform.Translate(Vector3.down * speed);
            float pos = player[0].transform.position.y;
            Debug.Log($"{pos}");

            if (Mathf.Abs(pos) > 50)
            {
                Debug.Log("Game Over");

            }

        }
    }
    private void OnDrawGizmos()
    {
        Vector3 forward = player[0].TransformDirection(rayRotation.normalized);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(player[0].position, player[0].position + forward * rayDistance);
    }
}
