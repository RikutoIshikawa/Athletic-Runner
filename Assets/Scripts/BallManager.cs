using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ボールの生成を行うスクリプト
public class BallManager : MonoBehaviour
{
    //////////////////
    //生成するボール//
    //////////////////
    
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;

    //////////////////////////////
    //ボールを生成するための情報//
    //////////////////////////////

    public float generateTime;  //ボールを生成する間隔
    public int ballNumber;      //１ターンに生成したいボールの数 

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        //コルーチンの実行
        StartCoroutine("BallGenerate");
    }

    ////////////////////////
    //ボール生成コルーチン//
    ////////////////////////
    IEnumerator BallGenerate()
    {
        while (true) {
            //生成したいボールの数だけ繰り返す
            for (int i = 0; i < ballNumber; i++)
            {
                ////////////////////////
                //ボールを生成する間隔//
                ////////////////////////
                yield return new WaitForSeconds(generateTime);

                //////////////////////
                //ボールの位置を取得//
                //////////////////////
                
                Vector3 pos1 = ball1.transform.position;
                Vector3 pos2 = ball2.transform.position;
                Vector3 pos3 = ball3.transform.position;
                Vector3 pos4 = ball4.transform.position;
                Vector3 pos5 = ball5.transform.position;
                Vector3 pos6 = ball6.transform.position;

                ////////////////
                //ボールを生成//
                ////////////////
                
                Instantiate(ball1, pos1, Quaternion.identity);
                Instantiate(ball3, pos3, Quaternion.identity);
                Instantiate(ball5, pos5, Quaternion.identity);

                //間にラグを発生させる
                yield return new WaitForSeconds(0.5f);

                Instantiate(ball2, pos2, Quaternion.identity);
                Instantiate(ball4, pos4, Quaternion.identity);
                Instantiate(ball6, pos6, Quaternion.identity);
            }
        }
    }
}