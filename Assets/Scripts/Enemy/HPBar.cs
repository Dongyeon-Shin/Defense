using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    private EnemyController enemy;
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    private void Start()
    {
        slider.maxValue = enemy.FullHP;
        slider.value = enemy.FullHP;
        enemy.OnChangeHP.AddListener(SetValue);
    }
    public void SetValue(int value)
    {
        slider.value = value;
    }
}
