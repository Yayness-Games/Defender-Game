using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] float minTimeUntilExplode;
    [SerializeField] float maxTimeUntilExplode;
    [SerializeField] GameObject explosionPrefab;

    private void Start()
    {
        float timeUntilExplode = Random.Range(minTimeUntilExplode, maxTimeUntilExplode);
        StartCoroutine(WaitAndExplode(timeUntilExplode));
    }

    IEnumerator WaitAndExplode(float explosionDelay)
    {
        yield return new WaitForSeconds(explosionDelay);
        GameObject explosion = Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity)
            as GameObject;
        Destroy(gameObject);
    }
}
