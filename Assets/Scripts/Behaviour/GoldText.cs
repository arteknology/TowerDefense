using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    private Text text;
    private PlayerBehaviour _player;
    void Start()
    {
        text = GetComponent<Text>();
        _player = GameObject.FindWithTag("Player").GetComponent<PlayerBehaviour>();
    }

    private void Update()
    {
        text.text = " Gold: " + _player.gold;
    }


}
