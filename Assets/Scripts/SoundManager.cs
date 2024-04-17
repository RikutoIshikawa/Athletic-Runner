using UnityEngine;

//BGMやSEの管理をするスクリプト
public class SoundManager : MonoBehaviour
{
    //BGMの構造
    [SerializeField] AudioSource audioSourceBGM = default;  //スピーカー
    [SerializeField] AudioClip[] bgmClips = default;        //CD

    //SEの構造
    [SerializeField] AudioSource audioSourceSE = default;   //スピーカー
    [SerializeField] AudioClip[] seClips = default;         //CD
    
    //BGMの代入：列挙型
    public enum BGM
    {
        Title_BGM, 
        Game_BGM
    }

    //SEの代入：列挙型
    public enum SE
    {
        Button,
        Clear, 
        Jump,
        Trampoline, 
        Damage, 
        Coin
    }

    //シングルトン：どのコードからもアクセスできる
    public static SoundManager instance;

    //////////////
    //初期化関数//
    //////////////
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    ////////////////
    //スタート関数//
    ////////////////
    private void Start()
    {
        PlayBGM(BGM.Title_BGM);
    }

    ///////////////////////////////
    //指定したBGMを鳴らすメソッド//
    ///////////////////////////////
    public void PlayBGM(BGM bgm)
    {
        audioSourceBGM.clip = bgmClips[(int)bgm];
        audioSourceBGM.Play();
    }

    ///////////////////////////////
    //指定したBGMを止めるメソッド//
    ///////////////////////////////
    public void StopBGM(BGM bgm)
    {
        audioSourceBGM.clip = bgmClips[(int)bgm];
        audioSourceBGM.Stop();
    }

    //////////////////////////////
    //指定したSEを鳴らすメソッド//
    //////////////////////////////
    public void PlaySE(SE se)
    {
        audioSourceSE.PlayOneShot(seClips[(int)se]);
    }
}