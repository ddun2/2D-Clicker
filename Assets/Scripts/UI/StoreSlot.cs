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

    public void Set(int index)
    {
        button = GetComponent<Button>();

        nameText.text = GameManager.Instance.jellySO[index].jellyName;
        priceText.text = GameManager.Instance.jellySO[index].price.ToString();
        icon.sprite = GameManager.Instance.jellySO[index].sprite;
    }

    public void CreateJelly(int index)
    {
        Instantiate(GameManager.Instance.jellySO[index].jellyPrefab);
    }
}
