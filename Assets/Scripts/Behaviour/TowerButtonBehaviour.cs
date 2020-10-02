using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehaviour : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    [SerializeField] private Transform _infos;
    [SerializeField] private GameObject selected_tower;
    [SerializeField] public GameObject Player;
    [SerializeField] private Transform tower_placement;


    private bool _active;
    private Button _button;
    private bool mouse_in;
    private Image _image;
    private TowerBehaviour SelectedTower;
    private PlayerBehaviour _player;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _button = GetComponent<Button>();
        _infos.gameObject.SetActive(false);
        mouse_in = false;
        _active = false;
        SelectedTower = selected_tower.GetComponent<TowerBehaviour>();
        _player = Player.GetComponent<PlayerBehaviour>();
    }

    public void OnClick()
    {
        if (!_active)
        {
            Debug.Log(_player.Gold);
            if (_player.Gold >= SelectedTower.Cost && _player.Gold != 0)
            {
                _image.enabled = false;
                _infos.gameObject.SetActive(false);
                TowerBehaviour t = Instantiate(SelectedTower);
                t.Init(_tower);
                t.transform.position = tower_placement.position;
                _player.RemoveGold(_tower.Cost);
                _active = true;
            }
        }
    }

    public void OnPointerEnter()
    {
        if (!_active)
        {
            mouse_in = true;
            _infos.gameObject.SetActive(true);
            GameObject.Find("CostText").GetComponent<Text>().text = " Cost: " + _tower.Cost;
            GameObject.Find("DamageText").GetComponent<Text>().text = " Damage: " + _tower.Damage;
            GameObject.Find("AttackSpeedText").GetComponent<Text>().text = " Attack Speed: " + _tower.AttackSpeed;
        }
    }

    public void OnPointerExit()
    {
        if (!_active)
        {
            mouse_in = false;
            _infos.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (mouse_in)
        {
            _infos.transform.position = Input.mousePosition+new Vector3(1f,-1f,0);
        }
    }
}
