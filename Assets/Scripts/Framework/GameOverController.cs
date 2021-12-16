using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject Endings;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        switch (GameController.instance.organsAcquired)
        {
            case -1:
                Endings.transform.Find("DeadEnding").gameObject.SetActive(true);
                break;
            case 0:
                Endings.transform.Find("DeadEnding").gameObject.SetActive(true);
                break;
            case 1:
                Endings.transform.Find("AliveEnding").gameObject.SetActive(true);
                break;
            default:
                Endings.transform.Find("FrankenEnding").gameObject.SetActive(true);
                break;

        }    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
