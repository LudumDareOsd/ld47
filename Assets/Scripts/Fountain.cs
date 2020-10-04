using UnityEngine;

public class Fountain : MonoBehaviour
{
    public AudioSource fountainAudio;
    // Start is called before the first frame update
    void Start()
    {
        fountainAudio.volume = 0.25f;
        fountainAudio.loop = true;
        fountainAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
