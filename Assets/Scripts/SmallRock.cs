using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRock : MonoBehaviour
{

    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("BOOM");

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
    }

}
