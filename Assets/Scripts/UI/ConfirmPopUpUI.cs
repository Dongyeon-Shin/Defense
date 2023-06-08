using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmPopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["OkButton"].onClick.AddListener(() => { Application.Quit(); });
        buttons["CancelButton"].onClick.AddListener(() => { CloseUI(); });
    }
}
