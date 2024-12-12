using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject CameraFPS;
    public GameObject CameraThirdPerson;
    public AudioSource reverseAudioSource; // AudioSource for reverse sound
    public AudioClip reverseClip; // The reverse sound clip
    public GameObject reverseCamera; // Camera for reverse view

    void Start()
    {
        // Initially set the FPS camera to active, and the third-person camera to inactive.
        CameraFPS.SetActive(true);
        CameraThirdPerson.SetActive(false);
        reverseCamera.SetActive(false); // Make sure reverse camera is off initially
    }

    void Update()
    {
        // Check if the C key is pressed to switch between cameras
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchCamera();
        }

        // Check if the S key is being pressed and activate reverse mode immediately
        if (Input.GetKey(KeyCode.S))
        {
            ActivateReverse();
        }
        else
        {
            // If the S key is not pressed, deactivate reverse mode
            DeactivateReverse();
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

    // Activate the reverse camera and sound
    void ActivateReverse()
    {
        if (!reverseCamera.activeSelf)
        {
            reverseCamera.SetActive(true);
        }

        if (!reverseAudioSource.isPlaying)
        {
            reverseAudioSource.PlayOneShot(reverseClip);
        }
    }

    // Deactivate the reverse camera and stop the reverse sound
    void DeactivateReverse()
    {
        if (reverseCamera.activeSelf)
        {
            reverseCamera.SetActive(false);
        }

        if (reverseAudioSource.isPlaying)
        {
            reverseAudioSource.Stop();
        }
    }
}
