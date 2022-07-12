using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Maps.Data
{
    [CreateAssetMenu(fileName = "Maps database", menuName = "Create maps database", order = 1)]
    public class MapsDatabase : ScriptableObject
    {
        public MapData[] mapDatas;
    }
    [System.Serializable]
    public class MapData
    {
        public string Name;
        public string SceneName;
    }
}
