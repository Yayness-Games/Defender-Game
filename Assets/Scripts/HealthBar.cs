using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] float MaxHealth;
    [SerializeField] float CurrentHealth;

    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        MaxHealth = player.GetHealth();
        CurrentHealth = player.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentHealth = player.GetHealth();
        transform.localScale = new Vector3(CurrentHealth / MaxHealth, 1.0f, 1.0f);

    }
}
