using UnityEngine.SceneManagement;
using UnityEngine;

//ボタンを押した際にシーン移動をする関数を管理するスクリプト
public class Button_SceneManager : MonoBehaviour
{
    ///////////////////////////////
    //Level１にシーン移動する関数//
    ///////////////////////////////
    public void ButtonChange_Level1()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Level1_Sceneへ移動
        SceneManager.LoadScene("Level1_Scene", LoadSceneMode.Single);

        //タイトルBGMを止める
        SoundManager.instance.StopBGM(SoundManager.BGM.Title_BGM);

        //ゲームBGMを鳴らす
        SoundManager.instance.PlayBGM(SoundManager.BGM.Game_BGM);
    }

    ///////////////////////////////
    //Level２にシーン移動する関数//
    ///////////////////////////////
    public void ButtonChange_Level2()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Level2_Sceneへ移動
        SceneManager.LoadScene("Level2_Scene", LoadSceneMode.Single);

        //タイトルBGMを止める
        SoundManager.instance.StopBGM(SoundManager.BGM.Title_BGM);

        //ゲームBGMを鳴らす
        SoundManager.instance.PlayBGM(SoundManager.BGM.Game_BGM);
    }

    ////////////////////////////////
    //タイトルにシーン移動する関数//
    ////////////////////////////////
    public void ButtonChange_Title()
    {
        //ボタンSEを鳴らす
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //Title_Sceneへ移動
        SceneManager.LoadScene("Title_Scene", LoadSceneMode.Single);

        //タイトルBGMを鳴らす
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title_BGM);
    }
}