using System;
using Assets.Entites.Track;
using UnityEngine;

namespace Assets.Entites.Train
{
    public class TrainCarriage : MonoBehaviour
    {
        private float _length = 0.3f;
        
        public float Length { get { return _length; } }
		
        public void PlaceAt(TrackRoute route, float distance)
        {
            gameObject.transform.position = route.GetPointAtDistance(distance);
        }
    }
}
