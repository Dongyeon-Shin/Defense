using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField]
    private Transform archer;
    [SerializeField]
    private Transform arrowPoint;
    protected override void Awake()
    {
        base.Awake();

        data = GameManager.Resource.Load<TowerData>("Data/ArcherTowerData");
    }
    private void OnEnable()
    {
        StartCoroutine(LookRoutine());
        StartCoroutine(AttackRoutine());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator LookRoutine()
    {
        while (true)
        {
            if(enemyList.Count > 0)
            {
                archer.LookAt(enemyList[0].transform.position);
            }
            yield return null;
        }
    }
    IEnumerator AttackRoutine()
    {
        while (true)
        {
            if (enemyList.Count > 0)
            {
                Attack(enemyList[0]);
                yield return new WaitForSeconds(data.Towers[0].attackDelay);
            }
            else
            {
                yield return null;
            }
        }
    }
    public void Attack(EnemyController enemy)
    {
        Arrow arrow = GameManager.Resource.Instantiate<Arrow>("Prefabs/Arrow");
        arrow.SetTarget(enemy);
        arrow.SetDamage(data.Towers[0].damage); ;
    }
}
