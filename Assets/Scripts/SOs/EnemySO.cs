using UnityEngine;

[CreateAssetMenu(fileName = "EnemySO", menuName = "Scriptable Objects/EnemySO")]
public class EnemySO : ScriptableObject
{
    public EnemyDifficulty difficulty;
    public Sprite sprite;
    public float dropSpeed;
    public decimal pointsOnKill;
}
