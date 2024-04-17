using UnityEngine;

//ゴールした際にクリアパネル表示を行うスクリプト
public class WhiteGoal : MonoBehaviour
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

            //PlayerManagerのWhiteGoal関数を呼び出す
            player.WhiteGoal();
        }
        //それ以外のオブジェクトの場合
        else
        {
            //特になにもしない
            return;
        }
    }
}