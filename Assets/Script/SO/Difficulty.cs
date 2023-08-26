using UnityEngine;

[CreateAssetMenu(fileName = "new difficulty", menuName = "Difficulty", order = 51)]
public class Difficulty : ScriptableObject
{
    [SerializeField] private int _enemiesCount;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _increasersChance;

    public int EnemiesCount => _enemiesCount;
    public float SpawnDelay => _spawnDelay;
    public float IncreasersChance => _increasersChance;    
}
