using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public Canvas storyCanvas;
    public float typeWriterDelay = 0.1f;
    public string storyText = "";
	public GameObject mapHandler;

	private int currentMap = 0;
    private Image headerImage;
    private Text headerText;
    private bool playerHasMoved = false;
    private bool textIsFinished = false;

    public void NextMap()
    {
		// Reload Scene - make this not reload LevelController
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		// Load next map
		mapHandler.GetComponent<MapHandler>().LoadMap(++currentMap);
        Reset();
        StartCoroutine(FadeInStoryText());
    }

    // Start is called before the first frame update
    private void Start()
    {
        headerImage = storyCanvas.GetComponentInChildren<Image>();
        headerText = storyCanvas.GetComponentInChildren<Text>();
		// Load next map
		mapHandler.GetComponent<MapHandler>().LoadMap(++currentMap);
		Reset();
		StartCoroutine(FadeInStoryText());
	}

	private void Update()
    {
        UpdatePlayerHasMoved();

        if (playerHasMoved && textIsFinished)
        {
            StartCoroutine(FadeOutStoryText());
        }
    }

    private void Reset()
    {
        headerText.text = "";
        storyCanvas.enabled = headerImage.enabled = headerText.enabled = false;
        textIsFinished = false;
        playerHasMoved = false;
    }

    private void UpdatePlayerHasMoved()
    {
        if (!playerHasMoved && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            playerHasMoved = true;
        }
    }

    private IEnumerator ShowText()
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

    private IEnumerator FadeInStoryText()
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

    private IEnumerator FadeOutStoryText()
    {
        for (float i = 1f; i >= 0; i -= Time.deltaTime)
        {
            headerImage.color = new Color(1, 1, 1, i);
            headerText.color = new Color(255, 255, 255, i);
            yield return null;
        }
        storyCanvas.enabled = false;
    }
}
