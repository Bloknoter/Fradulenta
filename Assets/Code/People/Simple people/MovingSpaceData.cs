using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Maps.Data
{
    [CreateAssetMenu(fileName ="Space data", menuName = "New space data", order = 2)]
    public class MovingSpaceData : ScriptableObject
    {
        public Vector2 LeftUpCorner;
        public Vector2 RightDownCorner;

        public Vector2 GetRandomPoint()
        {
            return new Vector2(Random.Range(LeftUpCorner.x, RightDownCorner.x), Random.Range(RightDownCorner.y, LeftUpCorner.y));
        }
    }
}
