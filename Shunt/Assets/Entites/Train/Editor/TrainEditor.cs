using UnityEditor;
using UnityEngine;

namespace Assets.Entites.Train.Editor
{
    public class TrainEditor
    {
        [MenuItem("GameObject/Create Other/Train")]
        public static void CreateTrackRoute(MenuCommand command)
        {
            GameObject trainObject = new GameObject("Train");
            Undo.RegisterUndo(trainObject, "Undo Create " + "Train");
            Train train = trainObject.AddComponent<Train>();
        }
    }
}
