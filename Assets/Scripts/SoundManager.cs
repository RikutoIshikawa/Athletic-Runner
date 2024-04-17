using UnityEngine;

//BGM��SE�̊Ǘ�������X�N���v�g
public class SoundManager : MonoBehaviour
{
    //BGM�̍\��
    [SerializeField] AudioSource audioSourceBGM = default;  //�X�s�[�J�[
    [SerializeField] AudioClip[] bgmClips = default;        //CD

    //SE�̍\��
    [SerializeField] AudioSource audioSourceSE = default;   //�X�s�[�J�[
    [SerializeField] AudioClip[] seClips = default;         //CD
    
    //BGM�̑���F�񋓌^
    public enum BGM
    {
        Title_BGM, 
        Game_BGM
    }

    //SE�̑���F�񋓌^
    public enum SE
    {
        Button,
        Clear, 
        Jump,
        Trampoline, 
        Damage, 
        Coin
    }

    //�V���O���g���F�ǂ̃R�[�h������A�N�Z�X�ł���
    public static SoundManager instance;

    //////////////
    //�������֐�//
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
    //�X�^�[�g�֐�//
    ////////////////
    private void Start()
    {
        PlayBGM(BGM.Title_BGM);
    }

    ///////////////////////////////
    //�w�肵��BGM��炷���\�b�h//
    ///////////////////////////////
    public void PlayBGM(BGM bgm)
    {
        audioSourceBGM.clip = bgmClips[(int)bgm];
        audioSourceBGM.Play();
    }

    ///////////////////////////////
    //�w�肵��BGM���~�߂郁�\�b�h//
    ///////////////////////////////
    public void StopBGM(BGM bgm)
    {
        audioSourceBGM.clip = bgmClips[(int)bgm];
        audioSourceBGM.Stop();
    }

    //////////////////////////////
    //�w�肵��SE��炷���\�b�h//
    //////////////////////////////
    public void PlaySE(SE se)
    {
        audioSourceSE.PlayOneShot(seClips[(int)se]);
    }
}