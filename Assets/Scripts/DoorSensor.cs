using UnityEngine;

//ドアのセンサースクリプト
public class DoorSensor : MonoBehaviour
{
    //////////
    //扉情報//
    //////////

    public GameObject door1;    //door1
    public GameObject door2;    //door2

    DoorManager1 door1Manager;  //door1のdoorManagerコンポーネント
    DoorManager2 door2Manager;  //door2のdoorManagerコンポーネント

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        //コンポーネントの取得
        door1Manager = door1.GetComponent<DoorManager1>();
        door2Manager = door2.GetComponent<DoorManager2>();
    }

    ////////////////////////////////////////
    //トリガーが発生すると呼び出される関数//
    ////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        //触れたオブジェクトのタグがプレイヤーの場合
        if (other.CompareTag("Player"))
        {
            //PlayerのPlayerManagerコンポーネントを取得
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();

            //PlayerManagerのWhiteGoal関数を呼び出す
            if (player.Judgement_Coin() == true)
            {
                //ユーザが２枚のコインを持っていたら扉を開く
                door1Manager.DoorMove();
                door2Manager.DoorMove();
            }
        }
        //それ以外のオブジェクトの場合
        else
        {
            //特になにもしない
            return;
        }
    }
}