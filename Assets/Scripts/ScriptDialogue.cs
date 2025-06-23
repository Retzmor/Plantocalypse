using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class ScriptDialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float velocityText = 0.1f;
    private bool wasSkipped = false;
    private string[] dialogues;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject skipButton;
    public System.Action OnDialogueEnd;
    


    private int numberText;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == dialogues[numberText])
            {
                NextLine();
            }
            else
            {
                
                StopAllCoroutines();
                text.text = dialogues[numberText];
            }
        }
        
    }


    IEnumerator LineOfText()
    {
        foreach (char letter in dialogues[numberText].ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(velocityText);
        }
    }


    private void NextLine()
    {
        if (numberText < dialogues.Length -1)
        {
            numberText++;
            text.text = string.Empty;
            StartCoroutine(LineOfText());
        }

        else
        {
            
            DesactiveUI();
        }
        
    }

    public void SkipDialogue()
    {
        if (wasSkipped) return; 

        wasSkipped = true;
        StopAllCoroutines(); 
        text.text = "";
        DesactiveUI();
    }

    private void DesactiveUI()
    {
        dialoguePanel.SetActive(false);
        skipButton.SetActive(false);
        OnDialogueEnd?.Invoke();
    }

    public void SetDialogue(string[] newDialogues)
    {
        dialogues = newDialogues;
        numberText = 0;
        text.text = string.Empty;
        dialoguePanel.SetActive(true);
        skipButton.SetActive(true);
        wasSkipped = false;
        StartCoroutine(LineOfText());
    }
}
