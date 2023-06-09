using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private EnemyController enemy;
    private int damage;
    Vector3 targetPoint;

    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(ArrowRoutine());
    }
    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    IEnumerator ArrowRoutine()
    {
        while(true)
        {
            if (enemy != null)
            {
                targetPoint = enemy.transform.position;
            }

            //Vector3 vector = enemy.transform.position - transform.position;
            //Vector3 dir = vector.normalized;
            //transform.Translate(dir * speed * Time.deltaTime, Space.World);
            transform.LookAt(enemy.transform.position);
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            if (Vector3.Distance(targetPoint, transform.position) < 0.1f)
            {
                if (enemy != null)
                {
                    enemy.TakeHit(damage);
                }

                GameManager.Resource.Destroy(gameObject);
                yield break;
            }
        }
    }
}
