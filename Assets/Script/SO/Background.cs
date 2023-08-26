using UnityEngine;

[CreateAssetMenu(fileName = "new background", menuName = "Background", order = 51)]
public class Background : ScriptableObject
{
    [SerializeField] private GameObject _backgroundPrefab;

    public GameObject BackgroundPrefab => _backgroundPrefab;
}
