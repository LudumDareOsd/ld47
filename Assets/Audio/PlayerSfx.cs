using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClipArray;
    public float volume = 0.5f;
    int nextClip = 0;
    public float timeBetweenSteps = 0.75f;
    float stepTimer;
    bool leftLeg = false;

    void Update()
    {
        stepTimer += Time.deltaTime;
        if (stepTimer > timeBetweenSteps)
        {
            audioSource.pitch = leftLeg ? 0.75f : 0.95f;
            audioSource.PlayOneShot(RandomClip(), volume);
            nextClip = nextClip < audioClipArray.Length - 1 ? nextClip + 1 : 0;
            stepTimer = 0;
            leftLeg = !leftLeg;
        }
    }
    AudioClip RandomClip()
    {
        return audioClipArray[Random.Range(0, audioClipArray.Length - 1)];
    }
}
