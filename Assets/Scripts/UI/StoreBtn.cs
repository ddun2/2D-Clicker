using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreBtn : MonoBehaviour
{
    public GameObject storeUI;
    public Image currentImage;
    public Sprite clickOn;
    public Sprite clickOff;

    private bool isActive = false;

    public void Toggle()
    {
        storeUI.SetActive(!isActive);
        
        if (isActive)
        {
            currentImage.sprite = clickOn;
        }
        else
        {
            currentImage.sprite = clickOff;
        }

        isActive = !isActive;
    }   

    private void UpdateUI()
    {

    }
}
