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
        currentCutscene = inCutsceneNumber-1;
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
        
    }
    public void ContinueGame()
    {
        GameController.instance.BeginNextLevel();
    }
    public void FinishGame()
    {
        GameController.instance.LoadLevel("GameOver");
    }    
}
