using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int organsAcquired;
    public enum GameState { MainMenu, Level, Cutscene, End};
    public float timeLeftInMission = 120;
    float timeForLevel = 120; //Time to complete level
    public GameState currentState = GameState.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == GameState.Level)
        {
            timeLeftInMission -= Time.deltaTime;
            if (timeLeftInMission <= 0) TimeRanOut();
        }
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
        currentState = GameState.Cutscene;
        LoadLevel("Cutscenes");
        //BeginCutscene(organsAcquired);
        //CutsceneController.instance.BeginCutscene(organsAcquired);
    }

    public void BeginCutscene(int organsAcquired)
    {

    }
    public void BeginNextLevel()
    {
        timeLeftInMission = timeForLevel; //2 minutes
        currentState = GameState.Level;
        LoadLevel(organsAcquired);
    }
    public void TimeRanOut()
    {
        organsAcquired = -1;
        FinishGame();
    }
    public void PlayerDetected()
    {
        organsAcquired = -1;
        FinishGame();
    }
    public void FinishGame()
    {
        currentState = GameState.End;
        GameController.instance.LoadLevel("GameOver");
    }
}