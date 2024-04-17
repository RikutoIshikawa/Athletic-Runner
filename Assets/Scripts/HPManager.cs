using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//プレイヤーのHPを管理するスクリプト
public class HPManager : MonoBehaviour
{
    //////////////////////////////
    //HPが０になった時に扱う情報//
    //////////////////////////////
    
    //HPが０になった時のアニメーション
    Animator animator;

    //UnityEvent：関数の参照を沢山保持して一斉に実行できる参照型
    public UnityEvent onDieCallback = new UnityEvent();

    //////////////////
    //HPに関する情報//
    //////////////////

    public int life = 100; //最大HP量
    public Slider hpBar;   //HPバー

    ////////////////
    //スタート関数//
    ////////////////
    void Start()
    {
        //アニメーターコンポーネントを取得
        animator = GetComponent<Animator>();

        //HPバーの初期化
        if (hpBar != null)
        {
            hpBar.value = life;
        }
    }

    ////////////////////////////////
    //指定したダメージを与える関数//
    ////////////////////////////////
    public void Damage(int damage)
    {
        ////////////////
        //HPの値の管理//
        ////////////////
        
        //HPが０以下の場合、何もしない
        if (life <= 0) return;

        //HPが０以上の場合、
        life -= damage;

        //ダメージSEを流す
        SoundManager.instance.PlaySE(SoundManager.SE.Damage);

        ////////////////
        //HPバーの管理//
        ////////////////

        //HPバーが０ではない場合
        if (hpBar != null)
        {
            //HPを設定する
            hpBar.value = life;
        }

        //HPが０の場合
        if (life <= 0)
        {
            //Death関数を呼び出す
            Death();
        }
    }

    //////////////////////
    //HPを全回復する関数//
    //////////////////////
    public void Recovery() 
    {
        life = 100;
        hpBar.value = life;
    }

    //////////////////////////////////////////
    //HPが０以下になった時に呼び出される関数//
    //////////////////////////////////////////
    void Death()
    {
        //アニメーターのBool型パラメータ「Die」をtrueにする。
        animator.SetBool("Death", true);

        //キャラクターごとの固有の処理
        onDieCallback.Invoke();

        //PlayerのPlayerManagerコンポーネントを取得
        PlayerManager player = GetComponent<PlayerManager>();

        //PlayerManagerのHP_Death関数を呼び出す
        player.HP_Death();
    }
}