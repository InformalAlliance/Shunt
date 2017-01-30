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
        private float acceleration = 0.001f;
        private float maxSpeed = 0.02f;
        private float speed = 0;
        private bool isFirstFrame = true;
        private float positionOnRoute;

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
                return;
            }
            UpdatePosition();
        }

        private void PlaceOnRoute(TrackRoute route, float position = 0)
        {
            float distance = 0;
            foreach (var carriage in carriages)
            {
                var middle = carriage.Length / 2;
                carriage.PlaceAt(route, distance + middle + position);
                distance += carriage.Length;
            }
        }

        private void UpdateFirstFrame()
        {
            PlaceOnRoute(route);
        }

        private void UpdatePosition()
        {
            if (speed < maxSpeed)
            {
                speed += acceleration;
                if (speed > maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
            positionOnRoute += speed * Time.deltaTime * 100;
            if (positionOnRoute > route.Length - Length)
            { 
                positionOnRoute = 0;
                speed = 0;
            }
            PlaceOnRoute(route, positionOnRoute);
        }
    }
}
