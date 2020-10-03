using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Text storyTextObject;
    public Canvas storyCanvas;
    public float typeWriterDelay = 0.1f;
    public string storyText = "";
    private string currentText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 1; i <= storyText.Length; i++)
        {
            currentText = storyText.Substring(0, i);
            storyTextObject.text = currentText;

            yield return new WaitForSeconds(getDelay(i));
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
