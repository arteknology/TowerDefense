using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehaviour : MonoBehaviour
{
    [NonSerialized]public int gold;
    [SerializeField] private int starting_gold;
    void Start()
    {
        gold = starting_gold;
    }

}
