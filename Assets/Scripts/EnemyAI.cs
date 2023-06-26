using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] public float increaseSpeed = 10f;
    [SerializeField] public float decreaseSpeed = 10f;

    public float startHealth = 100f;
    public float elementalArmor = 100f;
    [SerializeField] private float health;

    public Image healthBar;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = Waypoints.waypoints[wavepointIndex];
        health = startHealth;
    }

    void Update()
    {
        if (GameStates.OnMenu == true)
        {
            return;
        }

        Vector3 direction_to_waypoint = target.position - transform.position;
        transform.Translate(direction_to_waypoint.normalized * speed * Time.deltaTime, Space.World);
        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    public void IncreaseSpeed()
    {
        speed += increaseSpeed;
    }

    public void IncreaseSpeedAndHealth()
    {
        speed += increaseSpeed;
        health += 10f;
    }

    public void DecreaseSpeedAndHealth()
    {
        speed -= decreaseSpeed;
        health -= 5f;
    }

    void GetNextWaypoint()
    {
        wavepointIndex++;

        if (wavepointIndex >= Waypoints.waypoints.Length)
        {
            PlayerStats.lives--;
            Destroy(gameObject);
            return;
        }

        target = Waypoints.waypoints[wavepointIndex];
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        GameEvents.EnemyDead();
        Destroy(gameObject);
        
        return;
    }
}
