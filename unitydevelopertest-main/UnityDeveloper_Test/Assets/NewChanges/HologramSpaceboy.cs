using UnityEngine;

public class HologramSpaceboy : MonoBehaviour
{
    [SerializeField] private GameObject spaceBoyHolo;
    [SerializeField] private GameObject spaceBoy;

    private Quaternion initialRotation;
    private Quaternion currentRotation;
    private bool isKeypadEnterPressed = false;

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

        if (Input.GetKeyDown(KeyCode.Return) && isKeypadEnterPressed)
        {
            ResetHologram();
        }
    }

    private void HandleArrowInput(KeyCode keyCode, float xRotation, float yRotation, float zRotation)
    {
        if (Input.GetKeyDown(keyCode))
        {
            ActivateHologram(xRotation, yRotation, zRotation);
            isKeypadEnterPressed = true;
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

        spaceBoy.transform.position += new Vector3(1,1,1);
        spaceBoy.transform.rotation = currentRotation;
    }
}
