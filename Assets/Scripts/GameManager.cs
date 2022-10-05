using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public List<string> partOneDialogue;
    public List<string> partTwoDialogue;
    public List<string> partThreeDialogue;
    public List<string> partFourDialogue;

    List<string> currentDialogue;

    int phaseIndex = 0;
    int dialogueIndex = 0;
    int yesNumber = 0;

    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    public TMP_Text dialogueBox;

    public string endingOne;
    public string endingTwo;

    public Animator grittyAnim;
    public Animator grimaceAnim;


    // Start is called before the first frame update
    void Start()
    {

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);

        currentDialogue = partOneDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];
        grittyAnim.SetTrigger("isTalking");

    }

    void SetDialogueText()
    {
        if (phaseIndex < 4)
        {
            dialogueBox.text = currentDialogue[dialogueIndex];
        }
    }

    public void AdvanceDialogue()
    {
        if (phaseIndex < 4)
        {

            dialogueIndex++;
            SetDialogueText();

            if (dialogueIndex == currentDialogue.Count - 1)
            {
                SetupChoices();
            }
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
    }

    void SetupChoices()
    {
        nextButton.SetActive(false);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
    }

    public void NoChoice()
    {
        GoToNextPart();
    }

    public void YesChoice()
    {
        yesNumber++;
        GoToNextPart();
    }

    void GoToNextPart()
    {

        nextButton.SetActive(true);
        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);

        dialogueIndex = 0;

        switch (phaseIndex)
        {
            case 0:
                phaseIndex = 1;
                currentDialogue = partTwoDialogue;
                break;
            case 1:
                phaseIndex = 2;
                currentDialogue = partThreeDialogue;
                break;
            case 2:
                phaseIndex = 3;
                currentDialogue = partFourDialogue;
                break;
            case 3:
                phaseIndex = 4;
                break;
            case 4:
                phaseIndex = 5;
                break;
        }

    SetDialogueText();

    }

    void GiveResults()
    {

        if (yesNumber > 3)
        {
            dialogueBox.text = endingOne;
        }
        else
        {
            dialogueBox.text = endingTwo;
        }
    }
}
