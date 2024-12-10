using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject CameraFPS;
    public GameObject CameraThirdPerson;

    void Start()
    {
        // Initially set the FPS camera to active, and the third-person camera to inactive.
        CameraFPS.SetActive(true);
        CameraThirdPerson.SetActive(false);
    }

    void Update()
    {
        // Check if the C key is pressed
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }
    }

    void SwitchCamera()
    {
        // Switch between FPS and Third-Person cameras
        if (CameraFPS.activeSelf)
        {
            CameraFPS.SetActive(false);
            CameraThirdPerson.SetActive(true);
        }
        else
        {
            CameraFPS.SetActive(true);
            CameraThirdPerson.SetActive(false);
        }
    }
}
