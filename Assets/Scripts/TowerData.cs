using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "Data/Tower")]
public class TowerData : ScriptableObject/*, ISerializationCallbackReceiver*/
{
    [SerializeField] TowerInfo[] towers;
    public TowerInfo[] Towers { get { return towers; } }

    //public void OnAfterDeserialize()
    //{
        
    //}

    //public void OnBeforeSerialize()
    //{
    //    throw new NotImplementedException();
    //}

    [Serializable]
    public class TowerInfo
    {
        public string name;
        public string description;

        public Tower tower;

        public float buildTime;
        public float buildCost;
        public float sellCost;
    }
}
