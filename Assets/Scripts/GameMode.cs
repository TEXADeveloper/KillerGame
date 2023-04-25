using UnityEngine;

[CreateAssetMenu(fileName = "New GameMode")]
public class GameMode : ScriptableObject
{
    public int[] killObjective = new int[4];
    public float[] spawnCooldown = new float[4];
}
