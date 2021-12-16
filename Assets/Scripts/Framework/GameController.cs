using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int organsAcquired;
    enum GameState { MainMenu, Level, Cutscene, End};
    GameState currentState = GameState.MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProgressState()
    {

    }

    public void LoadLevel(string inLevelName)
    {
            SceneManager.LoadScene(inLevelName);
    }
    public void LoadLevel(int inLevelIndex)
    {
        SceneManager.LoadScene(organsAcquired + 3); // +3 = number of scenes before the levels in build.
    }

    public void CompleteLevel()
    {
        organsAcquired++;
        LoadLevel("Cutscenes");
        //BeginCutscene(organsAcquired);
        //CutsceneController.instance.BeginCutscene(organsAcquired);
    }

    public void BeginCutscene(int organsAcquired)
    {

    }
    public void BeginNextLevel()
    {
        LoadLevel(organsAcquired);
    }    
}