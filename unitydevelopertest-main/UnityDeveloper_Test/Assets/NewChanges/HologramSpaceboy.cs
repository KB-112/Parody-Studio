using UnityEngine;

public class HologramSpaceboy : MonoBehaviour
{
    [SerializeField] private GameObject spaceBoy;

    private IRayDetection rayDetection;

    private float rotationEffectAngle = 90f;
    [SerializeField] private float rotationalSpeed;
    private Quaternion targetRotation;
    private bool rotationInProgress = false;

    private void Start()
    {
        rayDetection = GetComponent<IRayDetection>();
        rotationInProgress = false;
    }

    private void Update()
    {
        if (!rotationInProgress)
        {
            HandleArrowInput();
        }
        else
        {
            spaceBoy.transform.rotation = Quaternion.RotateTowards(spaceBoy.transform.rotation, targetRotation, Time.deltaTime * rotationalSpeed * 10);

            if (Quaternion.Angle(spaceBoy.transform.rotation, targetRotation) < 0.01f)
            {
                rotationInProgress = false;
                rayDetection.DistanceCheck();
            }
        }
    }

    private void HandleArrowInput()
    {
        float currentYPosition = spaceBoy.transform.rotation.eulerAngles.y;

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ActivateHologram(rotationEffectAngle, currentYPosition, rotationEffectAngle);
        }
    }

    private Quaternion ActivateHologram(float xRotation, float yPosition, float zRotation)
    {
        Quaternion currentRotation = spaceBoy.transform.rotation;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentRotation = Quaternion.Euler(0, yPosition, currentRotation.eulerAngles.z + zRotation);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentRotation = Quaternion.Euler(0, yPosition, currentRotation.eulerAngles.z - zRotation);
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
