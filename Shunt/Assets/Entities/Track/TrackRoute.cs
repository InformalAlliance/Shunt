using Assets.Entites.Track;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Entites.Track
{
    [ExecuteInEditMode]
    [Serializable]
    public class TrackRoute : MonoBehaviour
    {
        public List<TrackPiece> edges;
        public List<BezierPoint> startPoints;

        public float Length
        {
            get
            {
                float length = 0;
                foreach (var edge in edges)
                    length += edge.length;
                return length;
            }
        }

        public void AddAtBack(TrackPiece edge, BezierPoint startPoint)
        {
            edges.Insert(0, edge);
            startPoints.Insert(0, startPoint);
        }

        public void AddAtFront(TrackPiece edge, BezierPoint startPoint)
        {
            edges.Add(edge);
            startPoints.Add(startPoint);
        }

        public void RemoveFromBack()
        {
            edges.RemoveAt(edges.Count - 1);
            startPoints.RemoveAt(edges.Count - 1);
        }

        public void RemoveFromFront()
        {
            edges.RemoveAt(0);
            startPoints.RemoveAt(0);
        }

        public Vector3 GetPointAtDistance(float distance)
        {
            float rollingDistance = 0;
            foreach (var edge in edges)
            {
                if (rollingDistance + edge.length >= distance)
                {
                    float edgeDistance = distance - rollingDistance;
                    var point = edge.GetPointAtDistance(edgeDistance);
                    return point;
                }
                rollingDistance += edge.length;
            }
            return new Vector3();
        }
    }
}
