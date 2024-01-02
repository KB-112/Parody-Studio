using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWallDetection : MonoBehaviour
{
    public Transform[] player;
    public Vector3 rayRotation;
    public float rayDistance;
    public LayerMask layerMask;

    private void Update()
    {
        CheckHitbjPos();
    }
    void CheckHitbjPos()
    {
        RaycastHit hit;
        Vector3 forwardNoY = player[0].TransformDirection(rayRotation.normalized);
        if (!Physics.Raycast(player[0].transform.position, forwardNoY, out hit, rayDistance, layerMask))
        {
            Debug.Log("Hiting in Empty Space");


          

        }

    }
    private void OnDrawGizmos()
    {
        Vector3 forward = player[0].TransformDirection(rayRotation.normalized);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(player[0].position, player[0].position + forward * rayDistance);
    }
}
