using UnityEngine;

//�S�[�������ۂɃN���A�p�l���\�����s���X�N���v�g
public class WhiteGoal : MonoBehaviour
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
            player.WhiteGoal();
        }
        //����ȊO�̃I�u�W�F�N�g�̏ꍇ
        else
        {
            //���ɂȂɂ����Ȃ�
            return;
        }
    }
}