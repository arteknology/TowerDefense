using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Transform _infos;
    [SerializeField] private TowerBehaviour selected_tower;
    [SerializeField] private PlayerBehaviour _player;


    private Text _text;
    private Button _button;
    private bool mouse_in;


    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<Text>();
        _button.onClick.AddListener(OnClick);
        _infos.gameObject.SetActive(false);
        mouse_in = false;
    }

    void OnClick()
    {
        TowerBehaviour t = GameObject.Instantiate(selected_tower);
        t.Init(_tower, true);
        _player.SetSelectedTower(t);
    }

    public void OnPointerEnter()
    {
        mouse_in = true;
        _infos.gameObject.SetActive(true);
    }

    public void OnPointerExit()
    {
        mouse_in = false;
        _infos.gameObject.SetActive(false);
    }

    void Update()
    {
        if (mouse_in)
        {
            _infos.transform.position = Input.mousePosition+new Vector3(1f,-1f,0);
        }
    }
}
