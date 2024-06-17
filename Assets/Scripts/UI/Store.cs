using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Store : MonoBehaviour
{
    private Button[] buttons;
    private Image image;
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI priceText;

    private void Awake()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<StoreSlot>().Set(i);
        }
    }

    private void OnEnable()
    {
        
    }

    
}
