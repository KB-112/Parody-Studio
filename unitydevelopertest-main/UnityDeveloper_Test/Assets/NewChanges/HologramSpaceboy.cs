using UnityEngine;

public class HologramSpaceboy : MonoBehaviour, IRayDetection
{
    [SerializeField] private GameObject spaceBoy;

  
   

    private float rotationEffectAngle = 90f;
    [SerializeField] private float rotationalSpeed;
    private Quaternion targetRotation;
    private bool rotationInProgress = false;
    bool raycheck =false;

    private void Start()
    {
       
        
        rotationInProgress = false;
    }

    private void Update()
    {
        if (!rotationInProgress)
        {
            HandleArrowInput();
            raycheck = false;
        }
        else
        {
            spaceBoy.transform.rotation = Quaternion.RotateTowards(spaceBoy.transform.rotation, targetRotation, Time.deltaTime * rotationalSpeed * 10);

            if (Quaternion.Angle(spaceBoy.transform.rotation, targetRotation) < 0.01f)
            {
                rotationInProgress = false;
                raycheck = true;
              
                
            }
        }
    }
    public bool DistanceCheck()
    {
        return raycheck;
    }
    private void HandleArrowInput()
    {
        float currentYPosition = spaceBoy.transform.rotation.eulerAngles.y;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ActivateHologram(rotationEffectAngle, rotationEffectAngle, rotationEffectAngle);
        }
    }

    private Quaternion ActivateHologram(float xRotation, float yPosition, float zRotation)
    {
        Quaternion currentRotation = spaceBoy.transform.rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentRotation = Quaternion.Euler(0, yPosition, currentRotation.eulerAngles.z - zRotation);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentRotation = Quaternion.Euler(0, yPosition, currentRotation.eulerAngles.z  +zRotation);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentRotation *= Quaternion.Euler(xRotation, 0, 0); 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentRotation *= Quaternion.Euler(-xRotation, 0, 0); 
        }

        targetRotation = currentRotation;
        rotationInProgress = true;
        return currentRotation;
    }


}
