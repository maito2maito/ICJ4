using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public AudioSource soundSource1; // First AudioSource to play sound
    public AudioSource soundSource2; // Second AudioSource to play sound
    public AudioClip soundClip1; // First sound clip
    public AudioClip soundClip2; // Second sound clip
    public Collider customHitbox; // The custom hitbox you want to track

    // This function is called when another collider enters the trigger collider
    void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<Interactable>())
        {
            other.GetComponent<Interactable>().OnInteract();
        }
    }

    // This function can also be used for regular collision (non-trigger) detection
    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with another specific object (optional)
        if (collision.relativeVelocity.magnitude > 2f)
        {
            PlayCollisionSounds();
        }

    }

    // Function to play both collision sounds
    void PlayCollisionSounds()
    {
        // Play the first sound if it isn't already playing
        if (!soundSource1.isPlaying)
        {
            soundSource1.PlayOneShot(soundClip1);
        }

        // Play the second sound if it isn't already playing
        if (!soundSource2.isPlaying)
        {
            soundSource2.PlayOneShot(soundClip2);
        }
    }
}
