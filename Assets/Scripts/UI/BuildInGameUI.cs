using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildInGameUI : InGameUI
{
    private TowerPlace towerPlace;
    protected override void Awake()
    {
        base.Awake();

        buttons["BlockerButton"].onClick.AddListener(() => { CloseUI(); });
        buttons["ArchorButton"].onClick.AddListener( () => { BuildArchorTower(); });
        buttons["CanaonButton"].onClick.AddListener ( () => { BuildCanonTower(); });

    }
    public void BuildArchorTower()
    {
        TowerData archorTowerData = GameManager.Resource.Load<TowerData>("Data/ArchorTowerData");
        towerPlace.BuildTower(archorTowerData);
        CloseUI();
    }
    public void BuildCanonTower()
    {
        TowerData canonTowerData = GameManager.Resource.Load<TowerData>("Data/CanonTowerData");
        towerPlace.BuildTower(canonTowerData);
        CloseUI();
    }
   
}
