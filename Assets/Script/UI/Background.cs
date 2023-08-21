using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new background", menuName = "Background", order = 51)]
public class Background : ScriptableObject
{
    [SerializeField] private GameObject _backgroundPrefab;
}
