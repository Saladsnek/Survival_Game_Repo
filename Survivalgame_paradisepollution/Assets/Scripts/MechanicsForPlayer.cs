using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicsForPlayer : MonoBehaviour
{
    private float timeInDay = 20;
    public int daysPassed = 0;
    public float fatigue = 100;
    public GameObject timeInDayUI;
    public GameObject daysPassedUI;
    public GameObject fatigueUI;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(timeInDay);
        //Debug.Log(daysPassed);
        timeInDay -= Time.deltaTime;
        timeInDayUI.gameObject.GetComponent<Text>().text = ("TIME: " + (int)timeInDay);
        daysPassedUI.gameObject.GetComponent<Text>().text = ("DAY: " + daysPassed);
        fatigueUI.gameObject.GetComponent<Text>().text = ("FATIGUE: " + fatigue);
        if (timeInDay <= 10.0f)
        {
            fatigue -= 50;
        }
        if (timeInDay <= 0.1f)
        {
            timeInDay += 20.0f;
            daysPassed += 1;
            if (fatigue <= 50)
            {
                fatigue += 50;
            }
        } 
    }
    void OnTriggerEnter2D()
    {
        Debug.Log("touched bed");
        timeInDay = 0.1f;
    }
}
