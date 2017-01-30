using System;
using Assets.Entites.Track;
using UnityEngine;

namespace Assets.Entites.Train
{
    public class TrainCarriage : MonoBehaviour
    {
        private readonly float MaxSpeed = 0.5f;

        public TrackPiece currentTrackPiece;
        public float currentTrackPiecePosition = 0;
        public TrackDirection currentTrackDirection = TrackDirection.Forward;
        public float speed = 0.01f;
        public float acceleration = 0.01f;
        private float _length = 0.3f;
        
        public float Length { get { return _length; } }

        void Update()
        {
            //UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (speed == 0)
                return;
            
            if (speed < MaxSpeed)
                speed += acceleration;

            currentTrackPiecePosition += speed * Time.deltaTime;

            if (currentTrackPiecePosition >= currentTrackPiece.length)
            {
                var positionOnNext = currentTrackPiecePosition - currentTrackPiece.length;
                var nextPiece = GetNextPiece();
                if (nextPiece == null)
                {
                    speed = 0;
                    currentTrackPiecePosition = currentTrackPiece.length;
                }
                else
                {
                    currentTrackPiece = nextPiece;
                    currentTrackPiecePosition = positionOnNext;
                }
            }
            gameObject.transform.position = currentTrackPiece.GetPointAtDistance(currentTrackPiecePosition);
        }

        public void PlaceAt(TrackRoute route, float distance)
        {
            gameObject.transform.position = route.GetPointAtDistance(distance);
        }

        private TrackPiece GetNextPiece()
        {
            if (currentTrackDirection == TrackDirection.Forward)
                return currentTrackPiece.forwardActive;
            return currentTrackPiece.reverseActive;
        }
    }
}
