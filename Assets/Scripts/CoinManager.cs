using UnityEngine;

//�R�C���̋@�\�X�N���v�g
public class CoinManager : MonoBehaviour
{
    ////////////////
    //�R�C���̏��//
    ////////////////

    public float speed;         //��]���鑬�x
    public float time;          //�G����Ă��������܂ł̎���
    private float lifeTime;     //�o�ߎ���

    bool getFlag;               //�Q�b�g�t���O

    private Vector3 startPos;   //�����ʒu

    //�V���O���g���F�ǂ̃R�[�h������A�N�Z�X�ł���
    public static CoinManager instance;

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
     void Start()
    {
        //�Q�b�g�t���O��false
        getFlag = false;

        //�R�C����\��
        gameObject.SetActive(true);

        //�X�^�[�g�|�W�V�����̎擾
        startPos = transform.position;

        //���Ԃ̏�����
        lifeTime = time;
    }

    ////////////////////
    //�A�b�v�f�[�g�֐�//
    ////////////////////
    void Update()
    {
        ///////////////////////////////
        // �v���C���[�Ɋl�����ꂽ�ꍇ//
        ///////////////////////////////
        if (getFlag == true)
        {
            // �f������]
            transform.Rotate(Vector3.up * speed * 10f * Time.deltaTime, Space.World);

            // ���Ԃ����炷
            lifeTime -= Time.deltaTime;

            // ���Ԃ��O�ȉ��ɂȂ�����A�R�C�������ł�����
            if (lifeTime <= 0)
            {
                gameObject.SetActive(false);
            }
        }

        ////////////////////////////////////
        //�v���C���[�Ɋl������Ă��Ȃ��ꍇ//
        ////////////////////////////////////
        else
        {
            // ��������]����������
            transform.Rotate(Vector3.up * speed * Time.deltaTime, Space.World);
        }
    }

    //////////////////////////////////////////////////
    //�v���C���[���R�C���ɐG�ꂽ���ɌĂяo�����֐�//
    //////////////////////////////////////////////////
    private void OnTriggerEnter(Collider other)
    {
        // �R�C�����l���\���G�ꂽ�I�u�W�F�N�g���v���C���[�̏ꍇ
        if ((getFlag == false) && (other.CompareTag("Player")))
        {
            //�Q�b�g�t���O��True�ɂ���B
            getFlag = true;

            // �R�C������Ƀ|�b�v������
            transform.position = startPos + Vector3.up * 1.5f;

            //Player��PlayerManager�R���|�[�l���g���擾
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();

            //PlayerManager��CoinPlus�֐����Ăяo��
            player.CoinPlus();
        }
    }

    //////////////////////////////////////////////////////////////////
    //�v���C���[��������܂��̓v���C���[��HP���O�ɂȂ�ƌĂ΂��֐�//
    //////////////////////////////////////////////////////////////////
    public void Revival() 
    {
        //////////////////////////////
        //�R�C�����l������Ă���ꍇ//
        //////////////////////////////
        if (getFlag == true)
        {
            //�Q�b�g�t���O��false
            getFlag = false;

            //�R�C����\��
            gameObject.SetActive(true);

            //�Q�[���I�u�W�F�N�g�̈ʒu��������
            transform.position = startPos;

            //���Ԃ̏�����
            lifeTime = time;
        }

        ////////////////////////////////
        //�R�C�����l������Ă��Ȃ��ꍇ//
        ////////////////////////////////
        else 
        {
            //���ɉ������Ȃ�
            return;
        }
    }
}