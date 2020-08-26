using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy stuff")]
    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 100;
    [Header("Projectile stuff")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [Header("FX stuff")]
    [SerializeField] GameObject explosionVFX;
    [SerializeField] float durationOfExplosion;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] float deathSFXVolume = 0.7f;

    // Use this for initialization
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
        shotCounter -= Time.deltaTime;
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
            projectile,
            transform.position,
            Quaternion.identity
            ) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
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
            EnemyDeath();
        }
    }

    private void EnemyDeath()
    {
        FindObjectOfType<Level>().SubtractEnemy();
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSFXVolume);
    }
}
