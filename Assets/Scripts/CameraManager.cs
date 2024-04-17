using UnityEngine;

//�J�n����ON�EOFF������J�����̊Ǘ��X�N���v�g
public class CameraManager : MonoBehaviour
{
    //////////////
    //�J�������//
    //////////////
    
    public Camera ONCamera;             //�Q�[���J�n����ON�ɂ������J����
    public Camera[] OFFCameras;         //�Q�[���J�n����OFF�ɂ����J����

    //////////////////
    //�v���C���[���//
    //////////////////
    
    public GameObject player;           //�v���C���[
    CharacterController controller;     //�L�����N�^�[�R���g���[���[

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        ////////////////////////////
        //�v���C���[�̓������~�߂�//
        ////////////////////////////
        
        //�R���|�[�l���g���擾
        controller = player.GetComponent<CharacterController>();

        //�R���g���[���[�𖳌���
        controller.enabled = false;

        ////////////////////////
        //�}�E�X�J�[�\���̉���//
        ////////////////////////

        // �}�E�X�J�[�\����\��
        Cursor.visible = true;

        //�}�E�X�J�[�\���̃��b�N������
        Cursor.lockState = CursorLockMode.None;

        ////////////////
        //�J�����̐ݒ�//
        ////////////////

        //�V�[���J�n����ON�ɂ����J������ݒ�
        ONCamera.enabled = true;

        //����ȊO�̃J������OFF�ɂ���
        foreach (Camera camera in OFFCameras)
        {
            camera.enabled = false;
        }
    }
}