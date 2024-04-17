using UnityEngine;

//�J�n���ɕ\���E��\��������p�l���̊Ǘ��X�N���v�g
public class PanelManager : MonoBehaviour
{
    //////////////
    //�p�l�����//
    //////////////
    
    public GameObject FirstPanel;   //��ɕ\�������Ă����p�l��

    public GameObject[] Panels;     //��ɔ�\�������Ă����p�l�����X�g

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        //�V�[���J�n���ɕ\�����������p�l����\��
        FirstPanel.SetActive(true);

        //����ȊO�̃p�l���͔�\��
        foreach (GameObject panel in Panels)
        {
            panel.SetActive(false);
        }
    }
}