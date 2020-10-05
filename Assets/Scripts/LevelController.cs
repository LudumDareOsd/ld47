using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public float typeWriterDelay = 0.05f;
    public string storyText = "";
    public AudioSource ostAudioSource;
	public int currentMap = 1;
    public int maxMap = 9;
	private bool loadPrevious = false;
    private Image headerImage;
	private Text instructionsText;
	private Text headerText;

    private bool playerHasMoved = false;
    private bool textIsFinished = false;
    private Canvas storyCanvas;
    private GameObject mapHandler;

    public void Awake()
    {
        var objs = GameObject.FindObjectsOfType<LevelController>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        } else {
            DontDestroyOnLoad(this.gameObject);

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    // Start is called before the first frame update
    public void Start()
    {
        ostAudioSource.loop = true;
        ostAudioSource.Play();
    }

    public void Update()
    {
        UpdatePlayerHasMoved();

        if (playerHasMoved && textIsFinished)
        {
            StartCoroutine(FadeOutStoryText());
        }
    }

    public void Reload() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextMap()
    {
        currentMap++;

        if (currentMap >= maxMap) {
            currentMap = 1;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        storyCanvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        mapHandler = GameObject.Find("MapHandler");

        headerImage = storyCanvas.GetComponentInChildren<Image>();
        headerText = storyCanvas.GetComponentInChildren<Text>();
		instructionsText = GameObject.Find("Instructions").GetComponentInChildren<Text>();

		var mh = mapHandler.GetComponent<MapHandler>();
        mh.levelController = gameObject;
        mh.LoadMap(currentMap, loadPrevious);

		loadPrevious = false;
		Reset();

        StopAllCoroutines();
        StartCoroutine(FadeInStoryText());
    }

    public void PreviousMap()
    {
        currentMap--;
		loadPrevious = true;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Reset()
    {
        headerText.text = "";
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
            return storyText.Substring(i - 1, 1).IndexOfAny(new char[] { '?', '!', '.', ',' }) != -1 ? 0.2f : typeWriterDelay;
        }
    }

    private IEnumerator FadeInStoryText()
    {
        for (float i = 0f; i <= 1; i += Time.deltaTime)
        {
            headerImage.color = new Color(1, 1, 1, i);
            headerText.color = new Color(255, 255, 255, i);
			instructionsText.color = new Color(255, 255, 255, i);

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
			instructionsText.color = new Color(255, 255, 255, i);

			yield return null;
        }
    }
}
