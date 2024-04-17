using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�v���C���[���猩�č��̃h�A���J���X�N���v�g
public class DoorManager2 : MonoBehaviour
{
    //////////////
    //�h�A�̊J��//
    //////////////
    public void DoorMove()
    {
        //�R���[�`���̎��s
        StartCoroutine("DoorRotate");
    }

    //////////////////////////////////////////
    //�h�A���J���āA�P�b��ɕ���R���[�`��//
    //////////////////////////////////////////
    IEnumerator DoorRotate()
    {
        //////////////////
        //�h�A���J���֐�//
        //////////////////

        //�X�O��J��Ԃ�
        for (int turn = 0; turn < 90; turn++)
        {
            //�I�u�W�F�N�g�𒆐S��-�P�x�Â�]������
            transform.Rotate(0, -1, 0);

            //0.01�b�ҋ@
            yield return new WaitForSeconds(0.01f);
        }

        //�P�b�ԑҋ@
        yield return new WaitForSeconds(1.0f);

        ////////////////////
        //�h�A�����֐�//
        ////////////////////
        for (int turn = 0; turn < 90; turn++)
        {
            //�I�u�W�F�N�g�𒆐S�ɂP�x�Â�]������
            transform.Rotate(0, 1, 0);

            //0.01�b�ҋ@
            yield return new WaitForSeconds(0.01f);
        }
    }
}