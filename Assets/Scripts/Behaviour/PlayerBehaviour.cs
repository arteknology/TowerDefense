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


    private TowerBehaviour selected_tower;


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

    public void SetSelectedTower(TowerBehaviour tower)
    {   
        if(tower == null && selected_tower != null)
        {
           GameObject.Destroy(selected_tower.gameObject);
        } 
        selected_tower = tower;
        Debug.Log("SetTower");
    }

    void Update()
    {
        if(selected_tower != null)
        {
            Debug.Log("selected_tower != null");
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse.z = 0f;
            selected_tower.transform.position = mouse;
            if (Input.GetMouseButtonDown(0))
            {
                if (Gold >= selected_tower.Cost)
                {
                    RemoveGold(selected_tower.Cost);
                    selected_tower.Place();
                    selected_tower = null;
                }
                else
                {
                    //Display "pas assez de gold"
                }
            }

        }
    }
}
