using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]
public class ItemData : ScriptableObject
{
    public string name;
    public int weight;
    public Sprite icon;
    public virtual void UseItem()
    {

    }
}
