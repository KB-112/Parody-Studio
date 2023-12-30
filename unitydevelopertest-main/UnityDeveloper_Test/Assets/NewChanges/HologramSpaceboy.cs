using UnityEngine;

public class HologramSpaceboy : MonoBehaviour
{
    [SerializeField] private GameObject spaceBoyHolo;
    [SerializeField] private GameObject spaceBoy;

    private Quaternion initialRotation;
    private Quaternion currentRotation;
    private bool isKeypadEnterPressed = false;
    private bool hologramActive = false;
    private float activationTime = 0f;
    private float activationDuration = 2f; // Time duration for activation (2 seconds)

    private void Start()
    {
        initialRotation = spaceBoy.transform.rotation;
        currentRotation = initialRotation;
    }

    private void Update()
    {
        HandleArrowInput(KeyCode.UpArrow, 90f, 180f, 0f);
        HandleArrowInput(KeyCode.DownArrow, 90f, 180f, 180f);
        HandleArrowInput(KeyCode.LeftArrow, 0f, 180f, -90f);
        HandleArrowInput(KeyCode.RightArrow, 0f, 180f, 90f);

      

        // Check if the hologram has been active for more than 2 seconds
        if (hologramActive && Time.time >= activationTime + activationDuration)
        {
            isKeypadEnterPressed = false; // Allow re-activation
            hologramActive = false;
            spaceBoyHolo.SetActive(false);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return) && isKeypadEnterPressed)
            {
                ResetHologram();
            }
        }
    }

    private void HandleArrowInput(KeyCode keyCode, float xRotation, float yRotation, float zRotation)
    {
        if (Input.GetKeyDown(keyCode) && !hologramActive)
        {
            ActivateHologram(xRotation, yRotation, zRotation);
            isKeypadEnterPressed = true;
            hologramActive = true;
            activationTime = Time.time; // Record activation time
        }
    }

    private void ActivateHologram(float xRotation, float yRotation, float zRotation)
    {
        spaceBoyHolo.SetActive(true);
        spaceBoyHolo.transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        currentRotation = spaceBoyHolo.transform.rotation;
    }

    private void ResetHologram()
    {
        spaceBoyHolo.transform.rotation = initialRotation;
        spaceBoyHolo.SetActive(false);
        isKeypadEnterPressed = false;
        hologramActive = false;

        spaceBoy.transform.position += new Vector3(1, 1, 1);
        spaceBoy.transform.rotation = currentRotation;
    }
}
