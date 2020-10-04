using UnityEngine;

public class Box : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    private int platformMask;
    private bool isGrounded;
    public AudioClip[] boxClips;
    public AudioSource boxSource;
    public void Awake()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        platformMask = LayerMask.GetMask("Platform", "Box");
    }
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = IsGrounded();
    }

    // Update is called once per frame
    void Update()
    {
        var wasGrounded = isGrounded;
        isGrounded = IsGrounded();
        if (!wasGrounded && isGrounded)
        {
            if (boxSource.isPlaying)
            {
                boxSource.Stop();
            }
            boxSource.clip = RandomBoxClip();
            boxSource.Play();
        }
    }
    private bool IsGrounded()
    {
        int hits = Physics2D.RaycastAll(boxCollider.bounds.center, Vector2.down, 0.80f).Length;
        return hits > 2;
    }
    private AudioClip RandomBoxClip()
    {
        return boxClips[Random.Range(0, boxClips.Length - 1)];
    }
}
