using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MechanicsForPlayer : MonoBehaviour
{
    private float timeInDay = 120;
    private float fishTimer = 0;
    private float drinkTimer = 0;
    public int daysPassed = 0;
    public float fatigue = 0;
    public float health = 100;
    public float hunger = 100;
    public float thirst = 100;
    public GameObject timeInDayUI;
    public GameObject daysPassedUI;
    public GameObject fatigueUI;
    public GameObject healthUI;
    public GameObject hungerUI;
    public GameObject thirstUI;

    // Update is called once per frame
    void Update()
    {
        //UI UPDATES AND GENERAL TIME/HUNGER/THIRST INCREASES/DECREASES
        timeInDay -= Time.deltaTime;
        fatigue += Time.deltaTime / 2;
        hunger -= Time.deltaTime;
        thirst -= Time.deltaTime;
        fishTimer -= Time.deltaTime;
        drinkTimer -= Time.deltaTime;
        timeInDayUI.gameObject.GetComponent<Text>().text = ("TIME: " + (int)timeInDay);
        daysPassedUI.gameObject.GetComponent<Text>().text = ("DAY: " + daysPassed);
        fatigueUI.gameObject.GetComponent<Text>().text = ("FATIGUE: " + (int)fatigue);
        healthUI.gameObject.GetComponent<Text>().text = ("HEALTH: " + (int)health);
        hungerUI.gameObject.GetComponent<Text>().text = ("HUNGER: " + (int)hunger);
        thirstUI.gameObject.GetComponent<Text>().text = ("THIRST: " + (int)thirst);
        
        //AT END OF DAY OCCURANCES
        if (timeInDay <= 0.1f)
        {
            timeInDay += 120.0f;
            daysPassed += 1;
            if (fatigue != 0)
            {
                fatigue = 0.0f;
            }
            if (hunger != 100)
            {
                hunger = 100.0f;
            }
            if (thirst != 100)
            {
                thirst = 100.0f;
            }
        } 
        
        //FATIGUE EFFECTS
        if (fatigue >= 100)
        {
            timeInDay = 0.1f;
        }
        //if (fatigue >= 25)
        //{
        //    get
        //}

        //HUNGER AND THIRST AFFECTS ON HP
        if (hunger >= 50 && hunger <= 100 && thirst <= 100 && thirst >= 50 && health != 100)
        {
            health += Time.deltaTime;
        }
        else if (hunger <= 50 && thirst >= 50 || hunger >= 50 && thirst <= 50 || hunger <= 50 && thirst <= 50)
        {
            health -= Time.deltaTime;
        }
        else if (hunger <= 25 && thirst >= 25 || hunger >= 25 && thirst <= 25)
        {
            health -= Time.deltaTime * 2;
        }
        else if (hunger <= 25 && thirst <= 25)
        {
            health -= Time.deltaTime * 4;
        }

    }
    void OnTriggerEnter2D(Collider2D Collider)
    {
        //SLEEP TO MOVE TO NEXT DAY
        if (Collider.tag == "Bed")
        {
            Debug.Log("touched bed");
            timeInDay = 0.1f;
        }

        //FISHING, AND PREVENTING RAPID FOOD GAIN
        if (Collider.tag == "Fishing")
        {
            if(fishTimer <= 0)
            {
                Debug.Log("Fishing and eating");
                hunger += 10;
                fishTimer += 10.0f;
                if (fatigue >= 15)
                {
                    fatigue -= 15.0f;
                }
                if (fatigue <= 14)
                {
                    fatigue -= fatigue;
                }
            }
            else if(fishTimer >= 0.1)
            {
                Debug.Log("Cannot Fish yet");
            }
        }

        //DRINKING AND PREVENTING RAPID WATER GAIN
        if (Collider.tag == "Distill")
        {
            if(drinkTimer <= 0)
            {
                Debug.Log("Taken a Drink");
                thirst += 10;
                drinkTimer += 10.0f;
                if (fatigue >= 15)
                {
                    fatigue -= 15.0f;
                }
                if (fatigue <= 14)
                {
                    fatigue -= fatigue;
                }
            }
            else if(drinkTimer >= 0.1)
            {
                Debug.Log("Cannot get more water");
            }
        }
    }
}
