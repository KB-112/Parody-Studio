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

    private void ActivateHologram(float xRotation, float yPosition, float zRotation)
    {
        float currentZRotation = Mathf.Repeat(spaceBoy.transform.rotation.eulerAngles.z, 360f);
        float currentXRotation = Mathf.Repeat(spaceBoy.transform.rotation.eulerAngles.x, 360f);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentZRotation += zRotation;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentZRotation -= zRotation;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentXRotation += xRotation;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentXRotation -= xRotation;
        }
        spaceBoy.transform.position += new Vector3(1, 1, 1);
        targetRotation = Quaternion.Euler(currentXRotation, yPosition, currentZRotation);
        rotationInProgress = true;
    }
}
