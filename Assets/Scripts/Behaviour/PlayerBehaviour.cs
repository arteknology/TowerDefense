using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [NonSerialized] public int Gold = 12;
    [NonSerialized] public int Lives;


    //[SerializeField] private int starting_gold;
    [SerializeField] private int starting_lives;
    [SerializeField] private Text gold_text;
    [SerializeField] private Text lives_text;


    void Start()
    {
        Lives = starting_lives;

        UpdateGoldText();
        UpdateLivesText();
    }

    public void UpdateGoldText()
    {
        if (Gold <= 0)
        {
            Gold = 0;
        }
        gold_text.text = " Gold: " + Gold;

    }


    public void UpdateLivesText()
    {
        lives_text.text = " Lives: " + Lives;
    }

    public void AddGold(int amount)
    {
        Gold += amount;
        UpdateGoldText();
    }

    public void RemoveGold(int amount)
    {
        AddGold(-amount);
        Debug.Log(amount);
    }

    public void AddLife(int amount)
    {
        Lives += amount;
        UpdateLivesText();
    }

    public void RemoveLife(int amount)
    {
        AddLife(-amount);
    }

}
