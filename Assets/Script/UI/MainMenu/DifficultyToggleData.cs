using UnityEngine;

public class DifficultyToggleData : MonoBehaviour
{
    [SerializeField] private Difficulty _difficulty;

    public Difficulty Difficulty => _difficulty;
}
