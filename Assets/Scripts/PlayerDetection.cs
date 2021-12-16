using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDetection : MonoBehaviour
{
    //Have a list of detectors that currently can see the player
    public List<Detector> detectors;

    private float currentDetectionLevel;
    private float maximumDetectionLevel = 100;

    // Detection Gain
    // Stores time of last detection gain
    float lastDetectionGain;
    //Time interval between detection level increases / ticks
    float detectionGainRate = 1f;
    // Amount of detection level gained every increase / tick
    public float detectionGainAmount = 3f;

    // Detection Loss
    // Stores time of last detection loss
    float lastDetectionLoss;
    //Time interval between detection level decreases / ticks
    float detectionLossRate = 1f;
    // Amount of detection level lost every decrease / tick
    public float detectionLossAmount = 1f;

    public Image detectionBarImg;
    bool isLerpingDetection = false;
    private float timeScale = 0;
    private float lerpSpeed = 2.5f;
    private float targetDetectionLevel;

    private void Start()
    {
        detectors = new List<Detector>();
        lastDetectionGain = 0;
        currentDetectionLevel = 0;
    }

    private void Update()
    {
        if (detectors.Count != 0)
            GainDetection();
        else
            LoseDetection();

        if (currentDetectionLevel >= maximumDetectionLevel)
            OnDetectionFull();

        UpdateDetectionBar();
        //Debug.Log(currentDetectionLevel);
    }

    void GainDetection()
    {
        if(Time.time > detectionGainRate + lastDetectionGain)
        {
            lastDetectionGain = Time.time;
            currentDetectionLevel += detectors.Count * detectionGainAmount;
            ClampDetectionLevel();
            //UpdateDetectionBar();
        }

    }

    void LoseDetection()
    {
        if(Time.time > detectionLossRate + lastDetectionLoss)
        {
            lastDetectionLoss = Time.time;
            currentDetectionLevel -= detectionLossAmount;
            ClampDetectionLevel();
            //UpdateDetectionBar();
        }
    }

    void ClampDetectionLevel()
    {
        float value = Mathf.Clamp(currentDetectionLevel, 0, 100);
        currentDetectionLevel = value;
    }

    public void SetCurrentDetectionLevel(float value)
    {
        currentDetectionLevel = value;
    }

    public void ClearDetectorList()
    {
        foreach (Detector d in detectors)
            detectors.Remove(d);
    }

    void UpdateDetectionBar()
    {
        targetDetectionLevel = currentDetectionLevel/100;
        timeScale = 0;
        /* if (!isLerpingDetection)
             StartCoroutine("LerpDetection"); */
        if (detectionBarImg.fillAmount != targetDetectionLevel)
            detectionBarImg.fillAmount = Mathf.Lerp(detectionBarImg.fillAmount, targetDetectionLevel, Time.deltaTime * lerpSpeed); 
    }

    private IEnumerator LerpDetection()
    {
        //float startingDetectionLevel = detectionBarImg.fillAmount;

        isLerpingDetection = true;
        while(timeScale < 1)
        {
            timeScale += Time.deltaTime * lerpSpeed;
            detectionBarImg.fillAmount = (float) Mathf.Lerp(detectionBarImg.fillAmount, targetDetectionLevel, timeScale);
        }
        isLerpingDetection = false;

        yield return null;
    }

    void OnDetectionFull()
    {
        Debug.LogWarning("Game Over");
    }


}
