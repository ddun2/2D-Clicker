using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="JellySO", menuName ="JellySO/Jelly")]

public class JellySO : ScriptableObject
{    
    public int id;
    public int price;
    public string jellyName;

    public Sprite sprite;
    public GameObject jellyPrefab;
}
