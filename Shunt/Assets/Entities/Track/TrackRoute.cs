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
            for (int i = 0; i < edges.Count; i++)
            {
                var edge = edges[i];
                var startPoint = startPoints[i];
                
                if (rollingDistance + edge.length >= distance)
                {
                    float edgeDistance = distance - rollingDistance;
                    var edgeDistanceDirection = edge.FirstPoint == startPoint
                        ? edgeDistance
                        : edge.length - edgeDistance;
                    var point = edge.GetPointAtDistance(edgeDistanceDirection);
                    return point;
                }
                rollingDistance += edge.length;
            }
            return new Vector3();
        }

        public TrackRoute Reverse()
        {
            var route = gameObject.AddComponent<TrackRoute>();
            route.edges = new List<TrackPiece>();
            route.startPoints = new List<BezierPoint>();
            for (int i = edges.Count - 1; i >= 0; i--)
            {
                var edge = edges[i];
                var oldStartPoint = startPoints[i];
                route.edges.Add(edge);
                route.startPoints.Add(
                    edge.FirstPoint == oldStartPoint
                    ? edge.LastPoint
                    : edge.FirstPoint
                );
            }
            return route;
        }
    }
}
