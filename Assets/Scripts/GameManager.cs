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

    }
}
