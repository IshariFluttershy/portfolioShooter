using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UpdateShipsDataGUI : MonoBehaviour
{
    public ShipData data;

    [SerializeField]
    TextMeshProUGUI name;
    [SerializeField]
    TextMeshProUGUI life;
    [SerializeField]
    TextMeshProUGUI atk;
    [SerializeField]
    TextMeshProUGUI exp;
    [SerializeField]
    TextMeshProUGUI lvl;
    [SerializeField]
    TextMeshProUGUI pending;
    [SerializeField]
    TextMeshProUGUI id;

    [SerializeField]
    Sprite ship1;
    [SerializeField]
    Sprite ship2;
    [SerializeField]
    Sprite ship3;
    [SerializeField]
    Sprite ship4;

    [SerializeField]
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetShipDatas(ShipData p_data)
    {
        gameObject.SetActive(true);

        data = p_data;

        if (data.Level == 0)
            image.sprite = ship1;
        else if (data.Level == 1)
            image.sprite = ship2;
        else if (data.Level == 2)
            image.sprite = ship3;
        else 
            image.sprite = ship4;

        name.text = data.Name;
        life.text = "Life : " + data.Life;
        atk.text = "ATK : " + data.Attack;
        exp.text = "EXP : " + data.EXP;
        lvl.text = "LVL : " + data.Level;
        pending.text = "Pending : " + data.PendingRewards;
        id.text = "ID : " + data.Id;
    }

    public void LoadGameScene(int p_index)
    {
        string spritePath = "";
        if (data.Level >= 4)
            spritePath = "4";
        else
            spritePath = (data.Level + 1).ToString();

        PlayerPrefs.SetString("PlayerSpritePath", "images/ship" + spritePath);
        SceneManager.LoadScene(p_index);
    }
}
