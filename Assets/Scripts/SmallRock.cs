using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallRock : MonoBehaviour
{

    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 0;
    [SerializeField] float explosionRadius = 3;
    [SerializeField] GameObject explosionPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
        CreateExplosion();
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Destroy(gameObject);
            FindObjectOfType<GameSession>().AddToScore(scoreValue);
        }
    }

    private void CreateExplosion()
    {
        GameObject explosion = Instantiate(
            explosionPrefab,
            transform.position,
            Quaternion.identity)
            as GameObject;
        explosion.GetComponent<Bomb>().SetRadius(explosionRadius);
        explosion.GetComponent<Bomb>().Explode();
    }
}
