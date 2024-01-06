using UnityEngine;

public class walldetection : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 1.0f;
    [SerializeField] private LayerMask layerMask;
    private bool hitByWall = false;
    [SerializeField] private Transform raypos;
    [SerializeField] private Vector3[] rayRot;
    private Vector3 assignRot;

    IStopPlayer stopPlayer;
    private void Start()
    {
        stopPlayer = GetComponent<IStopPlayer>();
    }
    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            
           
           
                assignRot = rayRot[1];
            
           
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            assignRot = rayRot[0];
        }

        RaycastHit hit;
       

       
        if (Physics.Raycast(raypos.position, raypos.TransformDirection(assignRot), out hit, raycastDistance, layerMask))
        {
            Debug.Log("Hit wall by raycast");
            hitByWall = true;
            stopPlayer.StopPlayer();
        }
        else
        {
            hitByWall = false;
        }
    }

    public void OnDrawGizmos()
    {
        // Draw the ray in the Scene view for visualization purposes
        Gizmos.color = Color.white;
        Gizmos.DrawRay(raypos.position, raypos.TransformDirection(assignRot) * raycastDistance);
    }
}
