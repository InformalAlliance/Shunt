using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entites.Track
{
    [ExecuteInEditMode]
    [Serializable]
    public class TrackPiece : BezierCurve
    {
        public List<TrackPiece> forwardEdges;
        public List<TrackPiece> reverseEdges;

        public TrackPiece forwardActive;
        public TrackPiece reverseActive;
    }
}
