using Assets.Entites.Track;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Entites.Train
{
    public class Train : MonoBehaviour
    {
        public List<TrainCarriage> carriages;
        public TrackRoute route;
        private bool isFirstFrame = true;

        public float Length
        {
            get
            {
                float length = 0;
                foreach (var carriage in carriages)
                    length += carriage.Length;
                return length;
            }
        }

        void Update()
        {
            if (isFirstFrame)
            {
                isFirstFrame = false;
                UpdateFirstFrame();
            }
            UpdatePosition();
        }

        private void PlaceOnRoute(TrackRoute route)
        {
            float distance = 0;
            foreach (var carriage in carriages)
            {
                var middle = carriage.Length / 2;
                carriage.PlaceAt(route, distance + middle);
                distance += carriage.Length;
            }
        }

        private void UpdateFirstFrame()
        {
            PlaceOnRoute(route);
        }

        private void UpdatePosition()
        {
        }
    }
}
