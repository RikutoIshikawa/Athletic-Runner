using UnityEngine;

//�f�b�h�]�[���̐���X�N���v�g
public class DeadZoneScript : MonoBehaviour
{
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

            //PlayerManager��MoveStartPos�֐����Ăяo��
            player.MoveStartPos();
        }
        //����ȊO�̃I�u�W�F�N�g�̏ꍇ
        else
        {
            //�I�u�W�F�N�g��j�󂷂�
            Destroy(other.gameObject);
        }
    }
}