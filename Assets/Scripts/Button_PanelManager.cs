using UnityEngine;

//ボタンを押された際に指定されたパネルの表示切替を行うスクリプト
public class Button_PanelManager : MonoBehaviour
{
    //////////////
    //パネル情報//
    //////////////
    
    public GameObject ActivePanel;      // 表示させたいパネル
    public GameObject InactivePanel;    // 非表示にしたいパネル

    //////////////////////////////////////////////////////
    //ボタンを押された際に指定されたパネルを表示する関数//
    //////////////////////////////////////////////////////
    public void ButtonActive_Panel()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //パネルを表示
        ActivePanel.SetActive(true);
    }

    //////////////////////////////////////////////////////////
    //ボタンを押された際に指定されたパネルを非表示にする関数//
    //////////////////////////////////////////////////////////
    public void ButtonInactive_Panel()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //パネルを非表示
        InactivePanel.SetActive(false);
    }
}