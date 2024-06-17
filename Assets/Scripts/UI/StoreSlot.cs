using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlot : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Image icon;
    public int index;

    public Button button;

    private GameObject jelly;

    private void Awake()
    {
        button = GetComponent<Button>();
        jelly = GameObject.FindWithTag("Jelly");
    }

    private void Update()
    {
        if (int.Parse(priceText.text) <= GameManager.Instance.gold)
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }

    public void Set(int index)
    {
        button = GetComponent<Button>();

        nameText.text = GameManager.Instance.jellySO[index].jellyName;
        priceText.text = GameManager.Instance.jellySO[index].price.ToString();
        icon.sprite = GameManager.Instance.jellySO[index].sprite;
    }

    public void CreateJelly(int index)
    {        
        Instantiate(GameManager.Instance.jellySO[index].jellyPrefab).transform.SetParent(jelly.transform);

        GameManager.Instance.gold -= int.Parse(priceText.text);
    }
}
