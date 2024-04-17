using UnityEngine;

//開始時にON・OFFさせるカメラの管理スクリプト
public class CameraManager : MonoBehaviour
{
    //////////////
    //カメラ情報//
    //////////////
    
    public Camera ONCamera;             //ゲーム開始時にONにしたいカメラ
    public Camera[] OFFCameras;         //ゲーム開始時にOFFにしたカメラ

    //////////////////
    //プレイヤー情報//
    //////////////////
    
    public GameObject player;           //プレイヤー
    CharacterController controller;     //キャラクターコントローラー

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        ////////////////////////////
        //プレイヤーの動きを止める//
        ////////////////////////////
        
        //コンポーネントを取得
        controller = player.GetComponent<CharacterController>();

        //コントローラーを無効化
        controller.enabled = false;

        ////////////////////////
        //マウスカーソルの解除//
        ////////////////////////

        // マウスカーソルを表示
        Cursor.visible = true;

        //マウスカーソルのロックを解除
        Cursor.lockState = CursorLockMode.None;

        ////////////////
        //カメラの設定//
        ////////////////

        //シーン開始時にONにしたカメラを設定
        ONCamera.enabled = true;

        //それ以外のカメラはOFFにする
        foreach (Camera camera in OFFCameras)
        {
            camera.enabled = false;
        }
    }
}