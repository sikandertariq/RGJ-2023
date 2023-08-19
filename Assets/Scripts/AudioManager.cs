using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;  // Singleton instance

    public AudioSource deathSoundAudioSource;
    public AudioClip deathSoundClip;

    public AudioSource attackSoundAudioSource; // Add an AudioSource for attack sound
    public AudioClip attackSoundClip; // Add an AudioClip for attack sound

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);  // Ensure only one instance exists
            return;
        }
    }

    // Play the death sound
    public void PlayDeathSound()
    {
        deathSoundAudioSource.PlayOneShot(deathSoundClip);
    }

    // Play the attack sound
    public void PlayAttackSound()
    {
        attackSoundAudioSource.PlayOneShot(attackSoundClip);
    }
}
