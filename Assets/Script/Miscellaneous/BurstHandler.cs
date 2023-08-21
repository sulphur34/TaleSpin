using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BurstHandler : MonoBehaviour
{
    [SerializeField] GameObject _smallBirstPrefab;
    [SerializeField] GameObject _mediumBirstPrefab;
    [SerializeField] GameObject _bigBirstPrefab;


    public void CreateSmallBurst(Transform impactPosition)
    {
        Instantiate(_smallBirstPrefab, impactPosition.position, impactPosition.rotation);
    }

    public void CreateMediumBurst(Transform impactPosition)
    {
        Instantiate(_mediumBirstPrefab, impactPosition.position, impactPosition.rotation);
    }

    public void CreateBigBurst(Transform impactPosition)
    {
        Instantiate(_bigBirstPrefab, impactPosition.position, impactPosition.rotation);
    }

    public void DestroyEvent()
    {
        Destroy(gameObject);
    }
}
