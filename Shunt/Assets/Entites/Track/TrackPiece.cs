using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entites.Track
{
    [ExecuteInEditMode]
    [Serializable]
    public class TrackPiece : BezierCurve
    {
        public List<TrackPiece> edges;
        private List<TrackPiece> reverseEdges;
    }
}
