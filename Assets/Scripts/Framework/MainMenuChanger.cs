using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Endings;
    public GameObject playGameButton;
    bool notRun = true;
    void Start()
    {
        
    }

    private void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.currentState == GameController.GameState.End && notRun)
        {
            notRun = false;
            SetupMenu();
        }
    }
    void SetupMenu()
    {
        switch (GameController.instance.organsAcquired)
        {
            case -1:
                Endings.transform.Find("DeadEnding").gameObject.SetActive(true);
                playGameButton.GetComponent<Button>().interactable = false;
                playGameButton.GetComponentInChildren<Text>().text = "There's no point. He's gone.";
                break;
            case 0:
                Endings.transform.Find("DeadEnding").gameObject.SetActive(true);
                playGameButton.GetComponent<Button>().interactable = false;
                playGameButton.GetComponentInChildren<Text>().text = "There's no point. He's gone.";
                break;
            case 1:
                Endings.transform.Find("AliveEnding").gameObject.SetActive(true);
                playGameButton.GetComponent<Button>().interactable = false;
                playGameButton.GetComponentInChildren<Text>().text = "You saved him - And that's all that matters.";
                break;
            default:
                Endings.transform.Find("FrankenEnding").gameObject.SetActive(true);
                playGameButton.GetComponent<Button>().interactable = false;
                playGameButton.GetComponentInChildren<Text>().text = "You saved him - No matter the cost.";
                break;

        }
    }
}
