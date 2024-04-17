using UnityEngine;

//�{�^���������ꂽ�ۂɎw�肳�ꂽ�p�l���̕\���ؑւ��s���X�N���v�g
public class Button_PanelManager : MonoBehaviour
{
    //////////////
    //�p�l�����//
    //////////////
    
    public GameObject ActivePanel;      // �\�����������p�l��
    public GameObject InactivePanel;    // ��\���ɂ������p�l��

    //////////////////////////////////////////////////////
    //�{�^���������ꂽ�ۂɎw�肳�ꂽ�p�l����\������֐�//
    //////////////////////////////////////////////////////
    public void ButtonActive_Panel()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //�p�l����\��
        ActivePanel.SetActive(true);
    }

    //////////////////////////////////////////////////////////
    //�{�^���������ꂽ�ۂɎw�肳�ꂽ�p�l�����\���ɂ���֐�//
    //////////////////////////////////////////////////////////
    public void ButtonInactive_Panel()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //�p�l�����\��
        InactivePanel.SetActive(false);
    }
}