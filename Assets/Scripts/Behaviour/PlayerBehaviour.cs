using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    [NonSerialized] public int Gold;
    [NonSerialized] public int Lives;


    [SerializeField] private int starting_gold;
    [SerializeField] private int starting_lives;
    [SerializeField] private Text gold_text;
    [SerializeField] private Text lives_text;


    void Start()
    {
        Gold = starting_gold;
        Lives = starting_lives;

        UpdateGoldText();
        UpdateLivesText();
    }

    private void UpdateGoldText()
    {
        gold_text.text = " Gold: " + Gold;
    }


    private void UpdateLivesText()
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
