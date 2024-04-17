using JetBrains.Annotations;
using UnityEngine;

//������������������X�N���v�g
public class MoveManager : MonoBehaviour
{
    ////////////
    //�ړ����//
    ////////////

    public float movePos;       //�ړ�����
    public float speed;         //����
    public char Movedirection;  //���p
    private Vector3 startPos;   //�����ʒu

    private Rigidbody rb;       //���W�b�g�{�f�B

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        //�����ʒu�̎擾
        startPos = transform.position;

        //Rigidbody�R���|�[�l���g���擾
        rb = GetComponent<Rigidbody>();
    }

    ///////////////////////////////////////////////
    //FixedUpdate�֐��F��莞�Ԃ��ƂɌĂяo�����//
    //Update�֐��F�P�t���[���ɂP��@�@�@�@�@�@�@ //
    ///////////////////////////////////////////////
    void FixedUpdate()
    {
        //////////////////
        //���������鏈��//
        //////////////////

        //////////////
        //�v���X����//
        //////////////
        if (Movedirection == 'x')
        {
            //�w�肵�������Ƒ������擾
            float posX = startPos.x + Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(posX, startPos.y, startPos.z));
        }
        else if (Movedirection == 'y')
        {
            //�w�肵�������Ƒ������擾
            float posY = startPos.y + Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(startPos.x, posY, startPos.z));
        }
        else if (Movedirection == 'z')
        {
            //�w�肵�������Ƒ������擾
            float posZ = startPos.z + Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(startPos.x, startPos.y, posZ));
        }

        //////////////////////////////
        //�}�C�i�X�����F�啶���œ���//
        //////////////////////////////
        else if (Movedirection == 'X')
        {
            //�w�肵�������Ƒ������擾
            float posX = startPos.x - Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(posX, startPos.y, startPos.z));
        }
        else if (Movedirection == 'Y')
        {
            //�w�肵�������Ƒ������擾
            float posY = startPos.y - Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(startPos.x, posY, startPos.z));
        }
        else if (Movedirection == 'Z')
        {
            //�w�肵�������Ƒ������擾
            float posZ = startPos.z - Mathf.PingPong(Time.time * speed, movePos);

            //���W���X�V
            rb.MovePosition(new Vector3(startPos.x, startPos.y, posZ));
        }
        else {
            return;
        }
    }
}