using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�{�[���̐������s���X�N���v�g
public class BallManager : MonoBehaviour
{
    //////////////////
    //��������{�[��//
    //////////////////
    
    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
    public GameObject ball6;

    //////////////////////////////
    //�{�[���𐶐����邽�߂̏��//
    //////////////////////////////

    public float generateTime;  //�{�[���𐶐�����Ԋu
    public int ballNumber;      //�P�^�[���ɐ����������{�[���̐� 

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        //�R���[�`���̎��s
        StartCoroutine("BallGenerate");
    }

    ////////////////////////
    //�{�[�������R���[�`��//
    ////////////////////////
    IEnumerator BallGenerate()
    {
        while (true) {
            //�����������{�[���̐������J��Ԃ�
            for (int i = 0; i < ballNumber; i++)
            {
                ////////////////////////
                //�{�[���𐶐�����Ԋu//
                ////////////////////////
                yield return new WaitForSeconds(generateTime);

                //////////////////////
                //�{�[���̈ʒu���擾//
                //////////////////////
                
                Vector3 pos1 = ball1.transform.position;
                Vector3 pos2 = ball2.transform.position;
                Vector3 pos3 = ball3.transform.position;
                Vector3 pos4 = ball4.transform.position;
                Vector3 pos5 = ball5.transform.position;
                Vector3 pos6 = ball6.transform.position;

                ////////////////
                //�{�[���𐶐�//
                ////////////////
                
                Instantiate(ball1, pos1, Quaternion.identity);
                Instantiate(ball3, pos3, Quaternion.identity);
                Instantiate(ball5, pos5, Quaternion.identity);

                //�ԂɃ��O�𔭐�������
                yield return new WaitForSeconds(0.5f);

                Instantiate(ball2, pos2, Quaternion.identity);
                Instantiate(ball4, pos4, Quaternion.identity);
                Instantiate(ball6, pos6, Quaternion.identity);
            }
        }
    }
}