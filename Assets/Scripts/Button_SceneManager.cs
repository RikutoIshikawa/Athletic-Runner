using UnityEngine.SceneManagement;
using UnityEngine;

//�{�^�����������ۂɃV�[���ړ�������֐����Ǘ�����X�N���v�g
public class Button_SceneManager : MonoBehaviour
{
    ///////////////////////////////
    //Level�P�ɃV�[���ړ�����֐�//
    ///////////////////////////////
    public void ButtonChange_Level1()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Level1_Scene�ֈړ�
        SceneManager.LoadScene("Level1_Scene", LoadSceneMode.Single);

        //�^�C�g��BGM���~�߂�
        SoundManager.instance.StopBGM(SoundManager.BGM.Title_BGM);

        //�Q�[��BGM��炷
        SoundManager.instance.PlayBGM(SoundManager.BGM.Game_BGM);
    }

    ///////////////////////////////
    //Level�Q�ɃV�[���ړ�����֐�//
    ///////////////////////////////
    public void ButtonChange_Level2()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Level2_Scene�ֈړ�
        SceneManager.LoadScene("Level2_Scene", LoadSceneMode.Single);

        //�^�C�g��BGM���~�߂�
        SoundManager.instance.StopBGM(SoundManager.BGM.Title_BGM);

        //�Q�[��BGM��炷
        SoundManager.instance.PlayBGM(SoundManager.BGM.Game_BGM);
    }

    ////////////////////////////////
    //�^�C�g���ɃV�[���ړ�����֐�//
    ////////////////////////////////
    public void ButtonChange_Title()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Title_Scene�ֈړ�
        SceneManager.LoadScene("Title_Scene", LoadSceneMode.Single);

        //�^�C�g��BGM��炷
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title_BGM);
    }
}