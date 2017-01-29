﻿using System;
using Assets.Entites.Track;
using UnityEngine;

namespace Assets.Entites.Train
{
    public class TrainCarriage : MonoBehaviour
    {
        private readonly float NearlyOne = 0.99f;

        public TrackPiece currentTrackPiece;
        public float currentTrackPiecePosition = 0;
        public TrackDirection currentTrackDirection = TrackDirection.Forward;
        public float speed = 0.01f;

        void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (speed == 0)
                return;

            currentTrackPiecePosition += speed;

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

        private TrackPiece GetNextPiece()
        {
            if (currentTrackDirection == TrackDirection.Forward)
                return currentTrackPiece.forwardActive;
            return currentTrackPiece.reverseActive;
        }
    }
}
