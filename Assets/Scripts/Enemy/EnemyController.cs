using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int fullHP;
    public int FullHP { get { return fullHP; } }
    public UnityEvent<int> OnChangeHP;
    public UnityEvent OnDied;
    private EnemyMover mover;

    private void Awake()
    {
        mover = GetComponent<EnemyMover>();
    }

    public void TakeHit(int damage)
    {
        fullHP += -damage;
        OnChangeHP?.Invoke(fullHP);
        if (fullHP <= 0)
        {
            OnDied?.Invoke();
            GameManager.Destroy(gameObject);
        }
    }
}
