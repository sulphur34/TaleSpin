using UnityEngine;

public class PlaneToggleData : MonoBehaviour
{
    [SerializeField] private Plane _plane;

    public Plane Plane => _plane;
}
