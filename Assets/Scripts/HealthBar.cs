using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float currentHealth;

    Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        maxHealth = player.GetHealth();
        currentHealth = player.GetHealth();
    }

    void Update()
    {
        currentHealth = player.GetHealth();

        transform.localScale = new Vector3(currentHealth / maxHealth, 1.0f, 1.0f);
    }
}
