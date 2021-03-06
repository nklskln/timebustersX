﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestCar : MonoBehaviour
{
    public GameObject Car_New;
    public GameObject Car_Destroyed;

    //public GameObject Player;
    public GameObject Player;

    public Text VeloXText;
    public Text VeloYText;
    public Text VeloZText;

    public bool isFalling;
    public bool isDestroyed = false;

    public void Start()
    {
        Car_New.gameObject.SetActive(true);
        Car_Destroyed.gameObject.SetActive(false);
    }

    public void Update()
    {
        VeloXText.text = Player.GetComponent<CharacterController>().velocity.x.ToString();
        VeloYText.text = Player.GetComponent<CharacterController>().velocity.y.ToString();
        VeloZText.text = Player.GetComponent<CharacterController>().velocity.z.ToString();

        if (Player.GetComponent<CharacterController>().velocity.y < -7f)
        {
            isFalling = true;
        }

        else
        {
            isFalling = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isFalling)
        {
            if (!isDestroyed)
            {
                Car_New.gameObject.SetActive(false);
                Car_Destroyed.gameObject.SetActive(true);
                Debug.Log("Car Destroyed");
                isDestroyed = true;
            }

            if (isDestroyed)
            {
                Car_New.gameObject.SetActive(false);
                Car_Destroyed.gameObject.SetActive(true);
                Debug.Log("Car Destroyed");
                isDestroyed = true;
            }
        }

        if (!isFalling)
        {
            if (!isDestroyed)
            {
                Car_New.gameObject.SetActive(true);
                Car_Destroyed.gameObject.SetActive(false);
                Debug.Log("Car not Destroyed");
            }

            if (isDestroyed)
            {
                Car_New.gameObject.SetActive(false);
                Car_Destroyed.gameObject.SetActive(true);
                Debug.Log("Car Destroyed");
                isDestroyed = true;
            }
        }
    }
}
