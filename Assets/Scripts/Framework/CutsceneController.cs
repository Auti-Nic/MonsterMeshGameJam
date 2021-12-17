using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    bool cutsceneFinished;
    public GameObject cutSceneHolder;
    GameObject currentCutsceneTextHolder;
    public GameObject continueScreenHolder;
    int currentCutscene = 0;
    int currentLine = 0;
    //public static CutsceneController instance;
    // Start is called before the first frame update
    void Start()
    {
        //instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (cutSceneHolder == null) GameObject.Find("CutsceneHolder");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cutsceneFinished) FinishCutscene();
            else ProgressCutscene();
        }
    }
    private void Awake()
    {
        continueScreenHolder.SetActive(false);
        BeginCutscene(GameController.instance.organsAcquired);
    }
    void ProgressCutscene()
    {
        currentCutsceneTextHolder.transform.GetChild(currentLine).gameObject.SetActive(false);
        currentLine++;
        currentCutsceneTextHolder.transform.GetChild(currentLine).gameObject.SetActive(true);
        if (currentLine == currentCutsceneTextHolder.transform.childCount-1) cutsceneFinished = true;
    }
    public void BeginCutscene(int inCutsceneNumber)
    {
        if (cutSceneHolder == null) GameObject.Find("CutsceneHolder");
        currentCutscene = inCutsceneNumber;
        cutSceneHolder.transform.GetChild(currentCutscene).gameObject.SetActive(true);
        currentCutsceneTextHolder = cutSceneHolder.transform.GetChild(currentCutscene).Find("Canvas").Find("Text").gameObject;
        if (inCutsceneNumber == cutSceneHolder.transform.childCount) //Last cutscene
        {
            Transform continueButton = continueScreenHolder.transform.Find("Continue");
            continueButton.GetComponent<Button>().interactable = false;
            continueButton.GetComponentInChildren<Text>().text = "You've done all you can.";
        }

    }    
    void FinishCutscene()
    {
        cutSceneHolder.transform.GetChild(currentCutscene).gameObject.SetActive(false);
        continueScreenHolder.SetActive(true);
        if (currentCutscene + 1 == cutSceneHolder.transform.childCount)
            ShowButtons("You've done enough...", "You've done all you can.", 1);
        else if (currentCutscene == 0) ShowButtons("It's only natural to pass away", "Save your dog", 0);
        else if (currentCutscene == 1) ShowButtons("He'll live, that's all that matters", "He's still in danger, that's all that matters", 0);
        else ShowButtons("He's still in danger, we can't stop now", "We need to make sure he's healthy", 2);

    }
    void ShowButtons(string gameOverText, string continueText, int disableButtons)
    {
        Transform continueButton = continueScreenHolder.transform.Find("Continue");
        Transform gameOverButton = continueScreenHolder.transform.Find("Finish");
        continueButton.GetComponentInChildren<Text>().text = continueText;
        gameOverButton.GetComponentInChildren<Text>().text = gameOverText;
        if (disableButtons == 1) continueButton.GetComponent<Button>().interactable = false;
        else if (disableButtons == 2) gameOverButton.GetComponent<Button>().interactable = false;
        else if (disableButtons == 0)
        {
            gameOverButton.GetComponent<Button>().interactable = true;
            continueButton.GetComponent<Button>().interactable = true;
        }
        continueScreenHolder.SetActive(true);
    }
    public void ContinueGame()
    {
        GameController.instance.BeginNextLevel();
    }
    public void FinishGame()
    {
        GameController.instance.FinishGame();
    }    
}
