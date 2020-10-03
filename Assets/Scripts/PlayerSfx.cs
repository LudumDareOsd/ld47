using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] stepClips;
    public AudioClip[] shoveClips;
    public AudioClip landClip;
    public float volume = 0.5f;
    public float timeBetweenMovement = 0.5f;
    float movementTimer;
    bool leftLeg = false;
    private void PlayClips(AudioClip[] clips)
    {
        movementTimer += Time.deltaTime;
        if (movementTimer > timeBetweenMovement)
        {
            audioSource.pitch = leftLeg ? 0.75f : 0.95f;
            audioSource.PlayOneShot(RandomClip(clips), volume);
            movementTimer = 0;
            leftLeg = !leftLeg;
        }
    }
    public void PlayWalk()
    {
        PlayClips(stepClips);
    }
    public void PlayShoveBox()
    {
        PlayClips(shoveClips);
    }
    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landClip, volume);
    }
    AudioClip RandomClip(AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length - 1)];
    }
}
