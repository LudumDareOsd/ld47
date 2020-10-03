using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Canvas storyCanvas;
    public float typeWriterDelay = 0.1f;
    public string storyText = "";

    private Image headerImage;
    private Text headerText;
    private bool playerHasMoved = false;
    private bool textIsFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        headerImage = storyCanvas.GetComponentInChildren<Image>();
        headerText = storyCanvas.GetComponentInChildren<Text>();
        headerText.text = "";
        storyCanvas.enabled = headerImage.enabled = headerText.enabled = false;

        StartCoroutine(FadeIn());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerHasMoved = true;
        }

        if (playerHasMoved && textIsFinished)
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator ShowText()
    {
        for (int i = 1; i <= storyText.Length; i++)
        {
            headerText.text = storyText.Substring(0, i);
            
            if (i != storyText.Length) {
                yield return new WaitForSeconds(getDelay(i));
            } else
            {
                yield return null;
            }
        }

        textIsFinished = true;
    }

    private IEnumerator FadeIn()
    {
        storyCanvas.enabled = headerImage.enabled = headerText.enabled = true;

        for (float i = 0f; i <= 1; i += Time.deltaTime)
        {
            headerImage.color = new Color(1, 1, 1, i);
            headerText.color = new Color(255, 255, 255, i);

            yield return null;
        }

        StartCoroutine(ShowText());
    }

    private IEnumerator FadeOut()
    {
        for (float i = 1f; i >= 0; i -= Time.deltaTime)
        {
            headerImage.color = new Color(1, 1, 1, i);
            headerText.color = new Color(255, 255, 255, i);
            yield return null;
        }
        storyCanvas.enabled = false;
    }

    private float getDelay(int i)
    {
        if (i == storyText.Length)
        {
            return 4;
        }
        else
        {
            return storyText.Substring(i - 1, 1).IndexOfAny(new char[] { '?', '!', '.', ',' }) != -1 ? 1 : typeWriterDelay;
        }
    }
}
