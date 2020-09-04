using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    [SerializeField] GameObject particlePrefab;
    [SerializeField] int minParticles;
    [SerializeField] int maxParticles;
    [SerializeField] float minAngle;
    [SerializeField] float maxAngle;
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float health;

    [SerializeField] int rocks;

    // Start is called before the first frame update
    void Start()
    {
        rocks = Random.Range(minParticles, maxParticles);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            explode();
        }
    }

    private void explode()
    {
        for (int i = 0; i < rocks; i++)
        {
            GameObject smallRock = Instantiate(
                particlePrefab,
                transform.position,
                Quaternion.identity)
                as GameObject;
            smallRock.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(minAngle, maxAngle), Random.Range(minSpeed, maxSpeed) * -1);
        }
        Destroy(gameObject);
    }
}
