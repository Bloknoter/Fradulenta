using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilityEngine
{
    [CreateAssetMenu(fileName ="Abilities database", menuName ="Create abilities database", order = 0)]
    public class AbilityDatabase : ScriptableObject
    {
        public AbilityData[] abilityDatas;
        public int CurrentAblilityDataID;
    }

    [System.Serializable]
    public class AbilityData
    {
        public string Name;
        public string Description;
        public GameObject AbilityPrefab;
    }
}
