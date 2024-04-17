using UnityEngine;

//デッドゾーンの制御スクリプト
public class DeadZoneScript : MonoBehaviour
{
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

            //PlayerManagerのMoveStartPos関数を呼び出す
            player.MoveStartPos();
        }
        //それ以外のオブジェクトの場合
        else
        {
            //オブジェクトを破壊する
            Destroy(other.gameObject);
        }
    }
}