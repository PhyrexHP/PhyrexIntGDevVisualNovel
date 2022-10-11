using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public List<string> partOneDialogue;
    public List<string> partTwoYesDialogue;
    public List<string> partTwoNoDialogue;
    public List<string> partThreeYesDialogue;
    public List<string> partThreeNoDialogue;
    public List<string> partFourLeftDialogue;
    public List<string> partFourRightDialogue;
    public List<string> badEndDialogue;

    List<string> currentDialogue;

    int phaseIndex = 0;
    int dialogueIndex = 0;
    int yesNumber = 0;

    bool recentYes;

    public GameObject choiceOne;
    public GameObject choiceTwo;
    public GameObject nextButton;

    public TMP_Text dialogueBox;
    public TMP_Text choiceOneBox;
    public TMP_Text choiceTwoBox;

    public string endingOne;
    public string endingTwo;
    public string badEnd;

    public Animator grittyAnim;
    public Animator grimaceAnim;


    // Start is called before the first frame update
    void Start()
    {

        choiceOne.SetActive(false);
        choiceTwo.SetActive(false);
        choiceOneBox.text = "hell yeah!";
        choiceTwoBox.text = "hell no!";


        currentDialogue = partOneDialogue;
        dialogueBox.text = currentDialogue[dialogueIndex];
        grittyAnim.SetTrigger("isTalking");

    }

    void SetDialogueText()
    {
            dialogueBox.text = currentDialogue[dialogueIndex];
    }

    public void AdvanceDialogue()
    {
        if (phaseIndex < 5)
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
        if (phaseIndex < 4)
        {
            nextButton.SetActive(false);
            choiceOne.SetActive(true);
            choiceTwo.SetActive(true);
        }
        else
        {
            GoToNextPart();
        }
    }

    public void NoChoice()
    {
        recentYes = false;
        GoToNextPart();
    }

    public void YesChoice()
    {
        yesNumber++;
        recentYes = true;
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
                if (recentYes == true)
                {
                    currentDialogue = partTwoYesDialogue;
                }
                else
                {
                    currentDialogue = partTwoNoDialogue;
                }
                break;
            case 1:
                phaseIndex = 2;
                if (recentYes == true)
                {
                    currentDialogue = partThreeYesDialogue;
                    choiceOneBox.text = "LEFT";
                    choiceTwoBox.text = "RIGHT";
                }
                else
                {
                    currentDialogue = partThreeNoDialogue;
                    choiceOneBox.text = "LEFT";
                    choiceTwoBox.text = "RIGHT";
                }
                break;
            case 2:
                if (recentYes == true)
                {
                    phaseIndex = 3;
                    currentDialogue = partFourLeftDialogue;
                }
                else
                {
                    phaseIndex = 4;
                    currentDialogue = partFourRightDialogue;
                }
                break;
            case 3:
                phaseIndex = 5;
                break;
            case 4:
                currentDialogue = badEndDialogue;
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
