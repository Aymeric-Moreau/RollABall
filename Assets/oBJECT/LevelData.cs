using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{
    public float vitesseBall;
    public float ballRespawnAltitude;
    public string sceneName;
    public Sprite levelPreview;


}
