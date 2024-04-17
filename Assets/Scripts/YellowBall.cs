using UnityEngine;

//プレイヤーがボールに当たった際の制御スクリプト
public class YellowBall : MonoBehaviour
{
    ////////////////////////////////////////
    //トリガーが発生すると呼び出される関数//
    ////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        //触れたオブジェクトのタグがプレイヤーの場合
        if (other.CompareTag("Player"))
        {
            //HPManagerのコンポーネントを取得
            var status = other.GetComponent<HPManager>();

            //Damage関数を呼び出す
            status.Damage(10);
        }
    }
}