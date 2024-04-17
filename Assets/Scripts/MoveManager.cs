using JetBrains.Annotations;
using UnityEngine;

//動く床を往復させるスクリプト
public class MoveManager : MonoBehaviour
{
    ////////////
    //移動情報//
    ////////////

    public float movePos;       //移動距離
    public float speed;         //速さ
    public char Movedirection;  //方角
    private Vector3 startPos;   //初期位置

    private Rigidbody rb;       //リジットボディ

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        //初期位置の取得
        startPos = transform.position;

        //Rigidbodyコンポーネントを取得
        rb = GetComponent<Rigidbody>();
    }

    ///////////////////////////////////////////////
    //FixedUpdate関数：一定時間ごとに呼び出される//
    //Update関数：１フレームに１回　　　　　　　 //
    ///////////////////////////////////////////////
    void FixedUpdate()
    {
        //////////////////
        //往復させる処理//
        //////////////////

        //////////////
        //プラス方向//
        //////////////
        if (Movedirection == 'x')
        {
            //指定した距離と速さを取得
            float posX = startPos.x + Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(posX, startPos.y, startPos.z));
        }
        else if (Movedirection == 'y')
        {
            //指定した距離と速さを取得
            float posY = startPos.y + Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(startPos.x, posY, startPos.z));
        }
        else if (Movedirection == 'z')
        {
            //指定した距離と速さを取得
            float posZ = startPos.z + Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(startPos.x, startPos.y, posZ));
        }

        //////////////////////////////
        //マイナス方向：大文字で入力//
        //////////////////////////////
        else if (Movedirection == 'X')
        {
            //指定した距離と速さを取得
            float posX = startPos.x - Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(posX, startPos.y, startPos.z));
        }
        else if (Movedirection == 'Y')
        {
            //指定した距離と速さを取得
            float posY = startPos.y - Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(startPos.x, posY, startPos.z));
        }
        else if (Movedirection == 'Z')
        {
            //指定した距離と速さを取得
            float posZ = startPos.z - Mathf.PingPong(Time.time * speed, movePos);

            //座標を更新
            rb.MovePosition(new Vector3(startPos.x, startPos.y, posZ));
        }
        else {
            return;
        }
    }
}