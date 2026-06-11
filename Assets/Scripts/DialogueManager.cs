using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    [Header("Ink")]
    public TextAsset inkJSON;

    [Header("UI")]
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject continueIcon;

    [Header("Typewriter")]
    public float typingSpeed = 0.03f;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip typeSound;

    [Header("Fade")]
    public Image fadeImage;
    public float fadeDuration = 1.5f;

    public bool dialogueFinished = false;

    private Story story;

    private Coroutine typingCoroutine;

    private bool isTyping;

    private string currentLine;

    private void Start()
    {
        story = new Story(inkJSON.text);

        continueIcon.SetActive(false);

        if (fadeImage != null)
        {
            Color c = fadeImage.color;
            c.a = 0f;
            fadeImage.color = c;
        }

        ContinueStory();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteLine();
            }
            else
            {
                ContinueStory();
            }
        }
    }

    private void ContinueStory()
    {
        if (!story.canContinue)
        {
            EndDialogue();
            return;
        }

        currentLine = story.Continue().Trim();

        HandleTags();

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        typingCoroutine = StartCoroutine(TypeLine(currentLine));
    }

    private void HandleTags()
    {
        foreach (string tag in story.currentTags)
        {
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
                continue;

            string key = splitTag[0].Trim().ToLower();
            string value = splitTag[1].Trim();

            switch (key)
            {
                case "speaker":
                    SetSpeaker(value);
                    break;

                case "event":
                    ExecuteEvent(value);
                    break;
            }
        }
    }

    private void SetSpeaker(string speakerName)
    {
        nameText.text = speakerName;

        switch (speakerName)
        {
            case "Mate":
                nameText.color = Color.violet;
                break;

            case "Roke":
                nameText.color = Color.violet;
                break;

            case "Tincho":
                nameText.color = Color.violet;
                break;

            case "Santi":
                nameText.color = Color.violet;
                break;

            case "Dani":
                nameText.color = Color.violet;
                break;

            case "Chapatero":
                nameText.color = Color.violet;
                break;

            case "DsSound":
                nameText.color = Color.violet;
                break;

            default:
                nameText.color = Color.white;
                break;
        }
    }

    private void ExecuteEvent(string eventName)
    {
        switch (eventName)
        {
            case "FREEZE_SCREEN":
                FreezeScreen();
                break;
        }
    }

    private IEnumerator TypeLine(string line)
    {
        isTyping = true;

        continueIcon.SetActive(false);

        dialogueText.text = "";

        foreach (char letter in line)
        {
            dialogueText.text += letter;

            if (typeSound != null && audioSource != null)
            {
                if (letter != ' ')
                {
                    audioSource.PlayOneShot(typeSound, 0.1f);
                }
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;

        continueIcon.SetActive(true);
    }

    private void CompleteLine()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        dialogueText.text = currentLine;

        isTyping = false;

        continueIcon.SetActive(true);
    }

    private void FreezeScreen()
    {
        Debug.Log("FREEZE_SCREEN ejecutado");
    }

    private void EndDialogue()
    {
        Debug.Log("Diálogo terminado");

        dialogueFinished = true;

        StartCoroutine(FadeAndLoadScene());
    }

    private IEnumerator FadeAndLoadScene()
    {
        if (fadeImage == null)
        {
            SceneManager.LoadScene("Mapa santi");
            yield break;
        }

        float elapsedTime = 0f;

        Color color = fadeImage.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;

            color.a = Mathf.Lerp(
                0f,
                1f,
                elapsedTime / fadeDuration
            );

            fadeImage.color = color;

            yield return null;
        }

        SceneManager.LoadScene("Mapa santi");
    }
}


// Interacciones Mapa santi