using UnityEngine;

//�A�҃G���A�̐���X�N���v�g
public class WhiteReturn : MonoBehaviour
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

            //PlayerManager��WhiteGoal�֐����Ăяo��
            player.WhiteReturn();
        }
        //����ȊO�̃I�u�W�F�N�g�̏ꍇ
        else
        {
            //���ɂȂɂ����Ȃ�
            return;
        }
    }
}