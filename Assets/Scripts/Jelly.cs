using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    [HideInInspector]
    public int id;
    //[HideInInspector]
    public int level;
    //[HideInInspector]
    public float exp;

    public float requiredExp;

    private void Start()
    {
        StartCoroutine(GainJellyPerSecond());
    }

    // 1ÃÊ¸¶´Ù °æÇèÄ¡ ¹× Á©¸® È¹µæ
    IEnumerator GainJellyPerSecond()
    {
        while (true)
        {
            exp ++;
            GameManager.Instance.jelly += level;
            yield return new WaitForSeconds(1f);
        }        
    }
}
