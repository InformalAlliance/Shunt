using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entites.Track
{
    [ExecuteInEditMode]
    [Serializable]
    public class TrackPiece : BezierCurve
    {
        private const float sleeperSpacing = 0.1f;

        public List<TrackPiece> forwardEdges;
        public List<TrackPiece> reverseEdges;

        public TrackPiece forwardActive;
        public TrackPiece reverseActive;

        private List<GameObject> sleepers;
        private bool isFirstFrame = true;
        
        void Update()
        {
            if (isFirstFrame)
            {
                isFirstFrame = false;
                UpdateFirstFrame();
            }
        }

        protected void UpdateFirstFrame()
        {
            return;
            sleepers = new List<GameObject>();
            var rollingLength = 0f;
            while (rollingLength < length)
            {
                AddSleeper(rollingLength);
                rollingLength += sleeperSpacing;
            }
        }

        private void AddSleeper(float distance)
        {
            var point = GetPointAtDistance(distance);
            var sleeper = GameObject.CreatePrimitive(PrimitiveType.Cube);
            
            sleeper.gameObject.transform.position = point;
            sleepers.Add(sleeper);
            var scale = 0.1f;
            sleeper.gameObject.transform.localScale = new Vector3(scale * 5, scale / 2, scale);
            var angle = GetAngleAtDistance(distance);
            sleeper.gameObject.transform.eulerAngles = new Vector3(0, angle * 100, 0);
        }
    }
}
