using UnityEngine;

public class BackgroungToggleData : MonoBehaviour
{
    [SerializeField] private Background _background;

    public Background Background => _background;
}
