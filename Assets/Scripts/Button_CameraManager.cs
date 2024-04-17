using UnityEngine;

//ボタンを押された際に指定されたカメラに切り替えるスクリプト
public class Button_CameraManager : MonoBehaviour
{
    //////////////
    //カメラ情報//
    //////////////
    
    public Camera ONCamera;             //ボタンを押すことで、ONにするカメラ
    public Camera OFFCamera;            //ボタンを押すことで、OFFにするカメラ

    public GameObject InactivePanel;    // ボタンを押すことで、非表示にしたいパネル

    //////////////////
    //プレイヤー情報//
    //////////////////
    
    public GameObject player;           //プレイヤー
    CharacterController controller;     //キャラクターコントローラー

    //////////////////////////////////////////////////////////////////////////
    //ボタンを押された際に、カメラの切り替えと、パネル非表示を行うスクリプト//
    //////////////////////////////////////////////////////////////////////////
    public void Button_Function()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //カメラの切り替え
        OFFCamera.enabled = false;
        ONCamera.enabled = true;

        //パネルを非表示にする
        InactivePanel.SetActive(false);

        // マウスカーソルを非表示にし、位置を固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //プレイヤーの動きを解除する
        //コンポーネントを取得
        controller = player.GetComponent<CharacterController>();

        controller.enabled = true; //コントローラーを有効化
    }
}