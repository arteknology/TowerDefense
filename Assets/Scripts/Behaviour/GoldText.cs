using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldText : MonoBehaviour
{
    private TextAlignment text;
    private PlayerBehaviour _player;
    void Start()
    {
        text = GetComponent<Text>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        text.text = " Gold: " + PlayerBehaviour.gold;
    }


}
