using UnityEditor;
using UnityEngine;

namespace Assets.Entites.Track.Editor
{
    public class TrackRouteEditor
    {
        [MenuItem("GameObject/Create Other/Track Route")]
        public static void CreateTrackRoute(MenuCommand command)
        {
            GameObject routeObject = new GameObject("TrackRoute");
            Undo.RegisterUndo(routeObject, "Undo Create " + "Track Route");
            TrackRoute route = routeObject.AddComponent<TrackRoute>();
        }
    }
}
