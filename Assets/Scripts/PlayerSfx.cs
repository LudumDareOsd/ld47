using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] stepClips;
    public AudioClip shoveBoxClip;
    public AudioClip jumpClip;
    public float volume = 0.5f;
    int nextStepClip = 0;
    public float timeBetweenMovement = 0.5f;
    float movementTimer;
    bool leftLeg = false;
    public void PlayWalk()
    {
        movementTimer += Time.deltaTime;
        if (movementTimer > timeBetweenMovement)
        {
            audioSource.pitch = leftLeg ? 0.75f : 0.95f;
            audioSource.PlayOneShot(RandomClip(), volume);
            nextStepClip = nextStepClip < stepClips.Length - 1 ? nextStepClip + 1 : 0;
            movementTimer = 0;
            leftLeg = !leftLeg;
        }
    }
    public void PlayShoveBox()
    {
        movementTimer += Time.deltaTime;
        if (movementTimer > timeBetweenMovement)
        {
            audioSource.pitch = leftLeg ? 0.75f : 0.95f;
            audioSource.PlayOneShot(shoveBoxClip, volume);
            nextStepClip = nextStepClip < stepClips.Length - 1 ? nextStepClip + 1 : 0;
            movementTimer = 0;
            leftLeg = !leftLeg;
        }
    }
    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpClip, volume);
    }
    AudioClip RandomClip()
    {
        return stepClips[Random.Range(0, stepClips.Length - 1)];
    }
}
