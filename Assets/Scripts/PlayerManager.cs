using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//プレイヤーのキャラクター操作スクリプト
public class PlayerManager : MonoBehaviour
{
    //////////////////////////////////
    //キャラクター操作に使用する情報//
    //////////////////////////////////
    
    CharacterController controller;     //キャラクターコントロール変数
    Animator animator;                  //キャラクターモーション変数

    float walkSpeed = 3f;   // 歩行時の移動速度
    float runSpeed = 5f;    // 走行時の移動速度
    float jump = 8f;        // ジャンプ力
    float gravity = 10f;    // 重力の大きさ

    Vector3 moveDirection = Vector3.zero; //キャラクターが移動するベクトル量

    Vector3 startPos; //スタートポジション

    ///////////////////////////////////////////
    //ゴール時にWhiteGoal()関数で使用する情報//
    ///////////////////////////////////////////
    
    public Camera mainCamera;   //メインカメラ（キャラクターを追いかける）
    public Camera clearCamera;  //クリアカメラ（クリア画面を表示するカメラ）
    public GameObject Canvas;   //キャンバス（クリア画面）

    //////////////////////
    //コインに関する情報//
    //////////////////////

    public GameObject coin1;    //テクニックコースのコイン
    public GameObject coin2;    //ギミックコースのコイン

    CoinManager coinManager1;   //コインマネージャーコンポーネント
    CoinManager coinManager2;   //コインマネージャーコンポーネント

    private int coinNumber;     //コインの獲得枚数

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        ////////////////////////////////////////////////////
        //キャラクターのコントロールに使用する情報の初期化//
        ////////////////////////////////////////////////////

        //各コンポーネントを取得
        controller = this.gameObject.GetComponent<CharacterController>();
        animator = this.gameObject.GetComponent<Animator>();

        //スタートポジションの取得
        startPos = transform.position;

        /////////////////////////////////
        //ゲームクリア時の素材の初期化//
        ////////////////////////////////

        //メインカメラをONは、Button_CameraManagerで管理
        //クリアカメラをOFFは、CameraManagerで管理

        //キャンバスを非表示にする
        Canvas.SetActive(false);

        //////////////////////////////
        //コインの獲得枚数のリセット//
        //////////////////////////////

        //CoinManagerコンポーネントを取得
        coinManager1 = coin1.GetComponent<CoinManager>();
        coinManager2 = coin2.GetComponent<CoinManager>();

        //獲得数をリセット
        coinNumber = 0;
    }

    ////////////////////
    //アップデート関数//
    ////////////////////
    void Update()
    {
        //キャラクターコントローラーがONならば操作を繰り返す
        if (controller.enabled == true) {

            //////////////////////////////
            //WASD入力による移動量を計算//
            //////////////////////////////

            // 移動速度を取得（シフトキーを押すと走行、押さなければ歩行）
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            // カメラの向きを基準にした正面方向のベクトルを取得
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // 前後左右の入力（WASDキー）から、移動のためのベクトルを計算
            // Input.GetAxis("Vertical") は前後（WSキー）の入力値
            // Input.GetAxis("Horizontal") は左右（ADキー）の入力値
            Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //前後（カメラ基準）　 
            Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; //左右（カメラ基準）

            ////////////////////////
            //ジャンプや重力の処理//
            ////////////////////////
            
            //////////////////////////////////////////
            // isGrounded は地面にいるかどうかを判定//
            //////////////////////////////////////////
            if (controller.isGrounded)
            {   
                //計算した移動量分だけ移動する
                moveDirection = moveZ + moveX;

                //スペースキーが押された場合はジャンプ
                if (Input.GetButtonDown("Jump"))
                {
                    //ジャンプSEを鳴らす
                    SoundManager.instance.PlaySE(SoundManager.SE.Jump);

                    //ジャンプ力の分だけ移動する
                    moveDirection.y = jump;
                }
            }

            ////////////////////
            //地面にいない場合//
            ////////////////////
            else
            {
                // WASDの移動量に加えて、重力を効かせる（Y方向）
                moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;
            }

            //////////////////////////////////////////
            //アニメーションの命令の再生と移動の命令//
            //////////////////////////////////////////

            // SetFloat：移動速度に応じたアニメーションをセット
            animator.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);

            // LookAt；プレイヤーの向きを入力の向きに変更
            transform.LookAt(transform.position + moveZ + moveX);

            // Move：指定したベクトルだけ移動させる
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    ////////////////////////////////////////////////////////////
    //デッドゾーンに触れた際に、スタート位置に強制移動する関数//
    ////////////////////////////////////////////////////////////
    public void MoveStartPos()
    {
        ////////////////////////////
        //プレイヤーの動きを止める//
        ////////////////////////////
        
        controller.enabled = false;     //コントローラーを無効化

        moveDirection = Vector3.zero;   //移動情報をリセット

        ////////////////////////////////////////////////////////
        //プレイヤーをスタート地点へ送り、コントロールを有効化//
        ////////////////////////////////////////////////////////

        //プレイヤーの位置を初期位置に変更する
        transform.position = startPos + Vector3.up * 10f; ;

        //プレイヤーの向きを（0, 0, 0）に変更する
        transform.rotation = Quaternion.identity;

        //HPManagerのコンポーネントを取得
        var status = GetComponent<HPManager>();

        //recovery()関数を呼び出す
        status.Recovery();

        //コントローラーを有効化
        controller.enabled = true;

        ////////////////////////////////
        //コインに関する情報のリセット//
        ////////////////////////////////

        //獲得枚数を０にする
        coinNumber = 0;

        //コインを復活させる
        coinManager1.Revival();
        coinManager2.Revival();
    }

    ////////////////////////////////////////////////////////////////////////
    //黄色いトランポリンに触れた際に、ジャンプ力×３だけ上に飛ばされる関数//
    ////////////////////////////////////////////////////////////////////////
    public void YellowTrampoline()
    {
        //トランポリンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Trampoline);
        
        //上に飛ばす
        moveDirection.y = jump * 3;
    }

    ////////////////////////////////////////////////////////////////////////////
    //白いCubeに触れた際に、プレイヤーの行動を止めて、クリア画面を表示する関数//
    ////////////////////////////////////////////////////////////////////////////
    public void WhiteGoal() 
    {
        ////////////////////////////
        //プレイヤーの動きを止める//
        ////////////////////////////
        
        controller.enabled = false;     //コントローラーを無効化

        moveDirection = Vector3.zero;   //移動情報をリセット

        ////////////////////////
        //マウスカーソルの解除//
        ////////////////////////

        // マウスカーソルを表示する
        Cursor.visible = true;

        //マウスカーソルのロックを解除する
        Cursor.lockState = CursorLockMode.None;

        ////////////////////////////////////////////
        //カメラを切り替えて、キャンバスを表示する//
        ////////////////////////////////////////////

        //BGMを止める
        SoundManager.instance.StopBGM(SoundManager.BGM.Game_BGM);

        //クリアSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Clear);

        //メインカメラをOFFにして、クリアカメラをONにする
        mainCamera.enabled = false;
        clearCamera.enabled = true;

        //クリアキャンバスを表示する
        Canvas.SetActive(true);
    }

    //////////////////////////////////////////////////////////
    //中間ゴールに触れた際に、スタート位置に強制移動する関数//
    //////////////////////////////////////////////////////////
    public void WhiteReturn()
    {
        ////////////////////////////
        //プレイヤーの動きを止める//
        ////////////////////////////

        controller.enabled = false;     //コントローラーを無効化

        moveDirection = Vector3.zero;   //移動情報をリセット

        ////////////////////////////////////////////////////////
        //プレイヤーをスタート地点へ送り、コントロールを有効化//
        ////////////////////////////////////////////////////////

        //プレイヤーの位置を初期位置に変更する
        transform.position = startPos + Vector3.up * 10f; ;

        //プレイヤーの向きを（0, 0, 0）に変更する
        transform.rotation = Quaternion.identity;

        //HPManagerのコンポーネントを取得
        var status = GetComponent<HPManager>();

        //recovery()関数を呼び出す
        status.Recovery();

        //コントローラーを有効化
        controller.enabled = true;
    }

    ////////////////////////////////////////
    //HPが０になった際に、呼び出される関数//
    ////////////////////////////////////////
    public void HP_Death() 
    {
        ////////////////////////////
        //プレイヤーの動きを止める//
        ////////////////////////////

        controller.enabled = false;     //コントローラーを無効化

        moveDirection = Vector3.zero;   //移動情報をリセット

        ////////////////////////////////////////////////////////
        //プレイヤーをスタート地点へ送り、コントロールを有効化//
        ////////////////////////////////////////////////////////

        //プレイヤーの位置を初期位置に変更する
        transform.position = startPos + Vector3.up * 10f; ;

        //プレイヤーの向きを（0, 0, 0）に変更する
        transform.rotation = Quaternion.identity;

        //アニメーターのBool型パラメータ「Die」を false にする。
        animator.SetBool("Death", false);

        //HPManagerのコンポーネントを取得
        var status = GetComponent<HPManager>();

        //recovery()関数を呼び出す
        status.Recovery();

        //コントローラーを有効化
        controller.enabled = true;


        ////////////////////////////////
        //コインに関する情報のリセット//
        ////////////////////////////////

        //獲得枚数を０にする
        coinNumber = 0;

        //コインを復活させる
        coinManager1.Revival();
        coinManager2.Revival();
    }

    ////////////////////////////////////////
    //コインを獲得した際に呼び出される関数//
    ////////////////////////////////////////
    public void CoinPlus() 
    {
        //コインSEを流す
        SoundManager.instance.PlaySE(SoundManager.SE.Coin);

        //獲得枚数を増やす
        coinNumber++;
    }

    ////////////////////////////////////////
    //コインが２枚以上あるかどうか判定する//
    ////////////////////////////////////////
    public bool Judgement_Coin() 
    {
        //コインを２枚所持していればtrueを返す
        return (coinNumber == 2);
    }
}