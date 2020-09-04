using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

    [SerializeField] int damage = 100;
    [SerializeField] float waitBeforeDestroyed = 0;
    [SerializeField] bool needToHit = true;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        if (needToHit == true)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(waitBeforeDestroyed);
        Destroy(gameObject);
    }

    private void Start()
    {
        if (needToHit == false)
        {
            StartCoroutine(WaitAndDestroy());
        }
    }
}
