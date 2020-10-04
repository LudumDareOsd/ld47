using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] stepClips;
    public AudioClip[] shoveClips;
    public AudioClip landClip;
    public float landVolume = 0.5f;
    public float walkVolume = 0.1f;
    public float shoveVolume = 0.05f;
    public float timeBetweenMovement = 0.5f;
    float movementTimer;
    bool leftLeg = false;
    private void PlayClips(AudioClip[] clips, float volume)
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
        PlayClips(stepClips, walkVolume);
    }
    public void PlayShoveBox()
    {
        PlayClips(shoveClips, shoveVolume);
    }
    public void PlayLandSound()
    {
        audioSource.PlayOneShot(landClip, landVolume);
    }
    AudioClip RandomClip(AudioClip[] clips)
    {
        return clips[Random.Range(0, clips.Length - 1)];
    }
}
