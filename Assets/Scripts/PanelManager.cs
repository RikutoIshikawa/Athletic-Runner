using UnityEngine;

//開始時に表示・非表示させるパネルの管理スクリプト
public class PanelManager : MonoBehaviour
{
    //////////////
    //パネル情報//
    //////////////
    
    public GameObject FirstPanel;   //先に表示させておくパネル

    public GameObject[] Panels;     //先に非表示させておくパネルリスト

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        //シーン開始時に表示させたいパネルを表示
        FirstPanel.SetActive(true);

        //それ以外のパネルは非表示
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }
}