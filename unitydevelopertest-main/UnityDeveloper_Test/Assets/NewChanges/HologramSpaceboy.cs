using UnityEngine;

public class HologramSpaceboy : MonoBehaviour
{
    [SerializeField] private GameObject spaceBoy;
   
    private IRayDetection rayDetection;


    private void Start()
    {
        rayDetection = GetComponent<IRayDetection>();
       
    }

    private void Update()
    {
        HandleArrowInput(90f);
        
    }

    private void HandleArrowInput(float zRotation)
    {
        float currentYPosition = spaceBoy.transform.rotation.eulerAngles.y;
       
      
        if (Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
        {
          
            ActivateHologram(zRotation, currentYPosition, zRotation);
         
        }
     
    }

    private void ActivateHologram(float xRotation, float yPosition, float zRotation)
    {
        float currentZRotation = spaceBoy.transform.rotation.eulerAngles.z;
        float newZRotation = currentZRotation;
  
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            newZRotation += zRotation;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            newZRotation -= zRotation;
        }

        
        newZRotation = Mathf.Repeat(newZRotation, 360f);




        float currentxRotation = spaceBoy.transform.rotation.eulerAngles.x;
        float newxRotation = currentxRotation;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            newxRotation += xRotation;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            newxRotation -= xRotation;
        }


        newxRotation = Mathf.Repeat(newxRotation, 360f);
        



        Quaternion targetRotation = Quaternion.Euler(newxRotation, yPosition, newZRotation);
        spaceBoy.transform.rotation = targetRotation;
    }


}

