using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public float bulletSpeed = 70f;
    public float bulletDamage = 50f;
    public float fireExplosionRadius = 0f;
    public GameObject attackImpactEffect;

    public void AttackSeek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 bulletDirection = target.position - transform.position;
        float distanceThisFrame = bulletSpeed * Time.deltaTime;

        if (bulletDirection.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(bulletDirection.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject attackEffectInstance = Instantiate(attackImpactEffect, transform.position, transform.rotation);
        Destroy(attackEffectInstance, 2f);

        if (fireExplosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
        return;
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, fireExplosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage (Transform enemy)
    {
        EnemyAI e = enemy.GetComponent<EnemyAI>();

        if (e != null)
        {
            e.TakeDamage(bulletDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fireExplosionRadius);
    }
}
