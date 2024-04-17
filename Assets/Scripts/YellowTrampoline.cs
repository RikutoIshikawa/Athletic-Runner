using UnityEngine;

//トランポリンの制御スクリプト
public class YellowTrampoline : MonoBehaviour
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

            //PlayerManagerのYellowTrampoline関数を呼び出す
            player.YellowTrampoline();
        }
        //それ以外のオブジェクトの場合
        else
        {
           //特になにもしない
           return;
        }
    }
}