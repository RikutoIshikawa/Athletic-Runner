using UnityEngine;

//�h�A�̃Z���T�[�X�N���v�g
public class DoorSensor : MonoBehaviour
{
    //////////
    //�����//
    //////////

    public GameObject door1;    //door1
    public GameObject door2;    //door2

    DoorManager1 door1Manager;  //door1��doorManager�R���|�[�l���g
    DoorManager2 door2Manager;  //door2��doorManager�R���|�[�l���g

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        //�R���|�[�l���g�̎擾
        door1Manager = door1.GetComponent<DoorManager1>();
        door2Manager = door2.GetComponent<DoorManager2>();
    }

    ////////////////////////////////////////
    //�g���K�[����������ƌĂяo�����֐�//
    ////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        //�G�ꂽ�I�u�W�F�N�g�̃^�O���v���C���[�̏ꍇ
        if (other.CompareTag("Player"))
        {
            //Player��PlayerManager�R���|�[�l���g���擾
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();

            //PlayerManager��WhiteGoal�֐����Ăяo��
            if (player.Judgement_Coin() == true)
            {
                //���[�U���Q���̃R�C���������Ă���������J��
                door1Manager.DoorMove();
                door2Manager.DoorMove();
            }
        }
        //����ȊO�̃I�u�W�F�N�g�̏ꍇ
        else
        {
            //���ɂȂɂ����Ȃ�
            return;
        }
    }
}