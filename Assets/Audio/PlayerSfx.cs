using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public AudioClip shoveBoxClip;
    public AudioClip jumpClip;
    public float volume = 0.5f;
    int nextStepClip = 0;
    public float timeBetweenMovement = 0.75f;
    float movementTimer;
    bool leftLeg = false;
    public void PlayWalk()
    {
        movementTimer += Time.deltaTime;
        if (movementTimer > timeBetweenMovement)
        {
            audioSource.pitch = leftLeg ? 0.75f : 0.95f;
            audioSource.PlayOneShot(RandomClip(), volume);
            nextStepClip = nextStepClip < audioClipArray.Length - 1 ? nextStepClip + 1 : 0;
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
            nextStepClip = nextStepClip < audioClipArray.Length - 1 ? nextStepClip + 1 : 0;
            movementTimer = 0;
            leftLeg = !leftLeg;
        }
    }
    public void PlayJumpSound()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = jumpClip;
        audioSource.volume = volume / 2;
        audioSource.Play();
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
    }
}
