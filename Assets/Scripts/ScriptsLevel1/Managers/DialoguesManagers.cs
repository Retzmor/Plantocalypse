using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialoguesManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button _skipButton;
    [SerializeField] private float typingSpeed = 0.05f;
    [SerializeField] bool cooldown = false;

    private string[] dialogues;
    private int index = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    private CamerasManagers camManager;

    public delegate void DialogFinished();
    public DialogFinished OnDialoguesFinished;

    public Button SkipButton { get => _skipButton; set => _skipButton = value; }

    private void Start()
    {
        SkipButton.onClick.AddListener(SkipDialogue);
        camManager = FindAnyObjectByType<CamerasManagers>();
    }

    public void StartDialogues(string[] lines)
    {
        dialogues = lines;
        index = 0;
        dialoguePanel.SetActive(true);
        ShowNextDialogue();
    }

    private void Update()
    {
        if (!dialoguePanel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.Space) && cooldown)
        {
            cooldown = false;
            if (isTyping)
            {
                StopCoroutine(typingCoroutine);
                dialogueText.text = dialogues[index];
                isTyping = false;
                StartCoroutine(WaitAndEnableAdvance(2f));
            }
            else
            {
                ShowNextDialogue();
            }
        }
    }

    void ShowNextDialogue()
    {
        if (index >= dialogues.Length)
        {
            dialoguePanel.SetActive(false);
            OnDialoguesFinished?.Invoke();
            return;
        }

        if (index == 4)
            camManager.FocusOnStart();

        if (index == 5)
            camManager.ZoomOutInicio(10f); // Aumenta zoom para mostrar más mapa

        typingCoroutine = StartCoroutine(TypeText(dialogues[index]));
        index++;

        cooldown = false;
    }

    IEnumerator TypeText(string text)
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char c in text)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        StartCoroutine(WaitAndEnableAdvance(2f));
    }

    IEnumerator AutoNextDialogue()
    {
        yield return new WaitForSeconds(2f);
        ShowNextDialogue();
    }

    void SkipDialogue()
    {
        StopAllCoroutines();
        dialoguePanel.SetActive(false);
        OnDialoguesFinished?.Invoke();
    }

    IEnumerator WaitAndEnableAdvance(float delay)
    {
        yield return new WaitForSeconds(delay);
        cooldown = true;
        if (!isTyping) ShowNextDialogue(); // avance automático
    }

}

