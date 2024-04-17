using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//プレイヤーから見て左のドアを開くスクリプト
public class DoorManager2 : MonoBehaviour
{
    //////////////
    //ドアの開閉//
    //////////////
    public void DoorMove()
    {
        //コルーチンの実行
        StartCoroutine("DoorRotate");
    }

    //////////////////////////////////////////
    //ドアを開いて、１秒後に閉じるコルーチン//
    //////////////////////////////////////////
    IEnumerator DoorRotate()
    {
        //////////////////
        //ドアを開く関数//
        //////////////////

        //９０回繰り返す
        for (int turn = 0; turn < 90; turn++)
        {
            //オブジェクトを中心に-１度づつ回転させる
            transform.Rotate(0, -1, 0);

            //0.01秒待機
            yield return new WaitForSeconds(0.01f);
        }

        //１秒間待機
        yield return new WaitForSeconds(1.0f);

        ////////////////////
        //ドアを閉じる関数//
        ////////////////////
        for (int turn = 0; turn < 90; turn++)
        {
            //オブジェクトを中心に１度づつ回転させる
            transform.Rotate(0, 1, 0);

            //0.01秒待機
            yield return new WaitForSeconds(0.01f);
        }
    }
}