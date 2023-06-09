using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private EnemyController enemy;
    private int damage;
    Vector3 targetPoint;
    [SerializeField]
    private float time;
    public void SetTarget(EnemyController enemy)
    {
        this.enemy = enemy;
        targetPoint = enemy.transform.position;
        StartCoroutine(CanonRoutine());
    }
    IEnumerator CanonRoutine()
    {
        float xSpeed = (targetPoint.x - transform.position.x) / time;
        float zSpeed = (targetPoint.z - transform.position.z) / time;
        float ySpeed = -1 * (0.5f * Physics.gravity.y * time * time + transform.position.y)/ time;
        float curTime = 0;
        while (curTime < time)
        {
            curTime += Time.deltaTime;
            ySpeed += Physics.gravity.y * Time.deltaTime;
            transform.position += new Vector3(xSpeed, ySpeed, zSpeed) * Time.deltaTime;          
            yield return null;
        }
        Explosion();
        GameManager.Resource.Destroy(gameObject);
    }
    private void Explosion()
    {

    }
}
