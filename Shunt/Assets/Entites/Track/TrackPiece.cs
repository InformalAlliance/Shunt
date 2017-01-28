using Assets.Splines;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entites.Track
{
    [ExecuteInEditMode]
    [Serializable]
    public class TrackPiece : AdvancedBezierCurve
    {
        public List<TrackPiece> forwardEdges;
        public List<TrackPiece> reverseEdges;

        public TrackPiece forwardActive;
        public TrackPiece reverseActive;
    }
}
