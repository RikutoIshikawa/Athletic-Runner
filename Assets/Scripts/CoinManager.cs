using UnityEngine;

//コインの機能スクリプト
public class CoinManager : MonoBehaviour
{
    ////////////////
    //コインの情報//
    ////////////////

    public float speed;         //回転する速度
    public float time;          //触れられてから消えるまでの時間
    private float lifeTime;     //経過時間

    bool getFlag;               //ゲットフラグ

    private Vector3 startPos;   //初期位置

    //シングルトン：どのコードからもアクセスできる
    public static CoinManager instance;

    ////////////////
    //スタート関数//
    ////////////////
     void Start()
    {
        //ゲットフラグをfalse
        getFlag = false;

        //コインを表示
        gameObject.SetActive(true);

        //スタートポジションの取得
        startPos = transform.position;

        //時間の初期化
        lifeTime = time;
    }

    ////////////////////
    //アップデート関数//
    ////////////////////
    void Update()
    {
        ///////////////////////////////
        // プレイヤーに獲得された場合//
        ///////////////////////////////
        if (getFlag == true)
        {
            // 素早く回転
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            // 時間を減らす
            lifeTime -= Time.deltaTime;

            // 時間が０以下になったら、コインを消滅させる
            if (lifeTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        ////////////////////////////////////
        //プレイヤーに獲得されていない場合//
        ////////////////////////////////////
        else
        {
            // ゆっくり回転させ続ける
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    //////////////////////////////////////////////////
    //プレイヤーがコインに触れた時に呼び出される関数//
    //////////////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        // コインが獲得可能かつ触れたオブジェクトがプレイヤーの場合
        if ((getFlag == false) && (other.CompareTag("Player")))
        {
            //ゲットフラグをTrueにする。
            getFlag = true;

            // コインを上にポップさせる
            transform.position = startPos + Vector3.up * 1.5f;

            //PlayerのPlayerManagerコンポーネントを取得
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();

            //PlayerManagerのCoinPlus関数を呼び出す
            player.CoinPlus();
        }
    }

    //////////////////////////////////////////////////////////////////
    //プレイヤーが落ちるまたはプレイヤーのHPが０になると呼ばれる関数//
    //////////////////////////////////////////////////////////////////
    public void Revival() 
    {
        //////////////////////////////
        //コインが獲得されている場合//
        //////////////////////////////
        if (getFlag == true)
        {
            //ゲットフラグをfalse
            getFlag = false;

            //コインを表示
            gameObject.SetActive(true);

            //ゲームオブジェクトの位置を初期化
            transform.position = startPos;

            //時間の初期化
            lifeTime = time;
        }

        ////////////////////////////////
        //コインが獲得されていない場合//
        ////////////////////////////////
        else 
        {
            //特に何もしない
            return;
        }
    }
}