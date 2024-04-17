using UnityEngine;

//�{�^���������ꂽ�ۂɎw�肳�ꂽ�J�����ɐ؂�ւ���X�N���v�g
public class Button_CameraManager : MonoBehaviour
{
    //////////////
    //�J�������//
    //////////////
    
    public Camera ONCamera;             //�{�^�����������ƂŁAON�ɂ���J����
    public Camera OFFCamera;            //�{�^�����������ƂŁAOFF�ɂ���J����

    public GameObject InactivePanel;    // �{�^�����������ƂŁA��\���ɂ������p�l��

    //////////////////
    //�v���C���[���//
    //////////////////
    
    public GameObject player;           //�v���C���[
    CharacterController controller;     //�L�����N�^�[�R���g���[���[

    //////////////////////////////////////////////////////////////////////////
    //�{�^���������ꂽ�ۂɁA�J�����̐؂�ւ��ƁA�p�l����\�����s���X�N���v�g//
    //////////////////////////////////////////////////////////////////////////
    public void Button_Function()
    {
        //�{�^��SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Button);

        //�J�����̐؂�ւ�
        OFFCamera.enabled = false;
        ONCamera.enabled = true;

        //�p�l�����\���ɂ���
        InactivePanel.SetActive(false);

        // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //�v���C���[�̓�������������
        //�R���|�[�l���g���擾
        controller = player.GetComponent<CharacterController>();

        controller.enabled = true; //�R���g���[���[��L����
    }
}