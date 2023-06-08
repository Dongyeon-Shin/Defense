using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePopUpUI : PopUpUI
{
    protected override void Awake()
    {
        base.Awake();

        buttons["ContinueButton"].onClick.AddListener(() => { CloseUI(); });
        buttons["SettingButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/SettingPopUpUI"); });
        buttons["ExitButton"].onClick.AddListener(() => { GameManager.UI.ShowPopUpUI<PopUpUI>("UI/ConfirmPopUpUI"); });
    }
}
