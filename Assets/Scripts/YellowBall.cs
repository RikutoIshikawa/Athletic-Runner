using UnityEngine;

//�v���C���[���{�[���ɓ��������ۂ̐���X�N���v�g
public class YellowBall : MonoBehaviour
{
    ////////////////////////////////////////
    //�g���K�[����������ƌĂяo�����֐�//
    ////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        //�G�ꂽ�I�u�W�F�N�g�̃^�O���v���C���[�̏ꍇ
        if (other.CompareTag("Player"))
        {
            //HPManager�̃R���|�[�l���g���擾
            var status = other.GetComponent<HPManager>();

            //Damage�֐����Ăяo��
            status.Damage(10);
        }
    }
}