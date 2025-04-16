using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class ScriptDialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[] dialogues;
    [SerializeField] float velocityText = 0.1f;
    private bool wasSkipped = false;
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] GameObject skipButton;
    [SerializeField] ControllerCamara cameraFocus;
    


    private int numberText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWithDelay());
          
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

    private void Interactions() 
    { 
    
        numberText = 0;
        StartCoroutine(LineOfText());
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
            cameraFocus.FocusEnemyThenReturn();
            DesactiveUI();
        }
        
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(1f); 
        Interactions(); 
    }

    

    public void SkipDialogue()
    {
        if (wasSkipped) return; 

        wasSkipped = true;
        StopAllCoroutines(); 
        text.text = "";
        DesactiveUI();
        cameraFocus.FocusEnemyThenReturn();
        
    }

    private void DesactiveUI()
    {
        dialoguePanel.SetActive(false);
        skipButton.SetActive(false);
    }
}
