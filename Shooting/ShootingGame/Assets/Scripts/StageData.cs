using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public Vector2 editLimitMin;
    public Vector2 editLimitMax;

    public Vector2 limitMin => editLimitMin;
    public Vector2 limitMax => editLimitMax;
}
