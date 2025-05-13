using UnityEngine;
using System.Collections.Generic;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpsPrefs = new List<GameObject>();

    private void OnDisable()
    {
        int rand = Random.Range(0, powerUpsPrefs.Count);
        Instantiate(powerUpsPrefs[rand], transform.position, Quaternion.identity);
    }
}
