using UnityEngine;


public class PlayerController 
{
    private Transform playerPosition;
    private float rayDistanceFromFloor = 0;
    private LayerMask floorMask;


    public PlayerController (float rayDistanceFromFloor, Transform playerPosition, LayerMask floorMask)
    {
        this.rayDistanceFromFloor = rayDistanceFromFloor;
       
        this.playerPosition = playerPosition;
        this.floorMask = floorMask;

    }

  
   

    public void  PlayerStandinginfo(Vector3 dir)
    {
        RaycastHit hit;
        
      

        if (Physics.Raycast(playerPosition.position, dir ,out hit, rayDistanceFromFloor, floorMask))
        {
                Debug.Log("Hit the floor"+hit.point);
               
        }
        
            

        
    }

    
}
