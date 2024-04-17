using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

//�v���C���[�̃L�����N�^�[����X�N���v�g
public class PlayerManager : MonoBehaviour
{
    //////////////////////////////////
    //�L�����N�^�[����Ɏg�p������//
    //////////////////////////////////
    
    CharacterController controller;     //�L�����N�^�[�R���g���[���ϐ�
    Animator animator;                  //�L�����N�^�[���[�V�����ϐ�

    float walkSpeed = 3f;   // ���s���̈ړ����x
    float runSpeed = 5f;    // ���s���̈ړ����x
    float jump = 8f;        // �W�����v��
    float gravity = 10f;    // �d�͂̑傫��

    Vector3 moveDirection = Vector3.zero; //�L�����N�^�[���ړ�����x�N�g����

    Vector3 startPos; //�X�^�[�g�|�W�V����

    ///////////////////////////////////////////
    //�S�[������WhiteGoal()�֐��Ŏg�p������//
    ///////////////////////////////////////////
    
    public Camera mainCamera;   //���C���J�����i�L�����N�^�[��ǂ�������j
    public Camera clearCamera;  //�N���A�J�����i�N���A��ʂ�\������J�����j
    public GameObject Canvas;   //�L�����o�X�i�N���A��ʁj

    //////////////////////
    //�R�C���Ɋւ�����//
    //////////////////////

    public GameObject coin1;    //�e�N�j�b�N�R�[�X�̃R�C��
    public GameObject coin2;    //�M�~�b�N�R�[�X�̃R�C��

    CoinManager coinManager1;   //�R�C���}�l�[�W���[�R���|�[�l���g
    CoinManager coinManager2;   //�R�C���}�l�[�W���[�R���|�[�l���g

    private int coinNumber;     //�R�C���̊l������

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        ////////////////////////////////////////////////////
        //�L�����N�^�[�̃R���g���[���Ɏg�p������̏�����//
        ////////////////////////////////////////////////////

        //�e�R���|�[�l���g���擾
        controller = this.gameObject.GetComponent<CharacterController>();
        animator = this.gameObject.GetComponent<Animator>();

        //�X�^�[�g�|�W�V�����̎擾
        startPos = transform.position;

        /////////////////////////////////
        //�Q�[���N���A���̑f�ނ̏�����//
        ////////////////////////////////

        //���C���J������ON�́AButton_CameraManager�ŊǗ�
        //�N���A�J������OFF�́ACameraManager�ŊǗ�

        //�L�����o�X���\���ɂ���
        Canvas.SetActive(false);

        //////////////////////////////
        //�R�C���̊l�������̃��Z�b�g//
        //////////////////////////////

        //CoinManager�R���|�[�l���g���擾
        coinManager1 = coin1.GetComponent<CoinManager>();
        coinManager2 = coin2.GetComponent<CoinManager>();

        //�l���������Z�b�g
        coinNumber = 0;
    }

    ////////////////////
    //�A�b�v�f�[�g�֐�//
    ////////////////////
    void Update()
    {
        //�L�����N�^�[�R���g���[���[��ON�Ȃ�Α�����J��Ԃ�
        if (controller.enabled == true) {

            //////////////////////////////
            //WASD���͂ɂ��ړ��ʂ��v�Z//
            //////////////////////////////

            // �ړ����x���擾�i�V�t�g�L�[�������Ƒ��s�A�����Ȃ���Ε��s�j
            float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            // �J�����̌�������ɂ������ʕ����̃x�N�g�����擾
            Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

            // �O�㍶�E�̓��́iWASD�L�[�j����A�ړ��̂��߂̃x�N�g�����v�Z
            // Input.GetAxis("Vertical") �͑O��iWS�L�[�j�̓��͒l
            // Input.GetAxis("Horizontal") �͍��E�iAD�L�[�j�̓��͒l
            Vector3 moveZ = cameraForward * Input.GetAxis("Vertical") * speed;  //�O��i�J������j�@ 
            Vector3 moveX = Camera.main.transform.right * Input.GetAxis("Horizontal") * speed; //���E�i�J������j

            ////////////////////////
            //�W�����v��d�͂̏���//
            ////////////////////////
            
            //////////////////////////////////////////
            // isGrounded �͒n�ʂɂ��邩�ǂ����𔻒�//
            //////////////////////////////////////////
            if (controller.isGrounded)
            {   
                //�v�Z�����ړ��ʕ������ړ�����
                moveDirection = moveZ + moveX;

                //�X�y�[�X�L�[�������ꂽ�ꍇ�̓W�����v
                if (Input.GetButtonDown("Jump"))
                {
                    //�W�����vSE��炷
                    SoundManager.instance.PlaySE(SoundManager.SE.Jump);

                    //�W�����v�͂̕������ړ�����
                    moveDirection.y = jump;
                }
            }

            ////////////////////
            //�n�ʂɂ��Ȃ��ꍇ//
            ////////////////////
            else
            {
                // WASD�̈ړ��ʂɉ����āA�d�͂���������iY�����j
                moveDirection = moveZ + moveX + new Vector3(0, moveDirection.y, 0);
                moveDirection.y -= gravity * Time.deltaTime;
            }

            //////////////////////////////////////////
            //�A�j���[�V�����̖��߂̍Đ��ƈړ��̖���//
            //////////////////////////////////////////

            // SetFloat�F�ړ����x�ɉ������A�j���[�V�������Z�b�g
            animator.SetFloat("MoveSpeed", (moveZ + moveX).magnitude);

            // LookAt�G�v���C���[�̌�������͂̌����ɕύX
            transform.LookAt(transform.position + moveZ + moveX);

            // Move�F�w�肵���x�N�g�������ړ�������
            controller.Move(moveDirection * Time.deltaTime);
        }
    }

    ////////////////////////////////////////////////////////////
    //�f�b�h�]�[���ɐG�ꂽ�ۂɁA�X�^�[�g�ʒu�ɋ����ړ�����֐�//
    ////////////////////////////////////////////////////////////
    public void MoveStartPos()
    {
        ////////////////////////////
        //�v���C���[�̓������~�߂�//
        ////////////////////////////
        
        controller.enabled = false;     //�R���g���[���[�𖳌���

        moveDirection = Vector3.zero;   //�ړ��������Z�b�g

        ////////////////////////////////////////////////////////
        //�v���C���[���X�^�[�g�n�_�֑���A�R���g���[����L����//
        ////////////////////////////////////////////////////////

        //�v���C���[�̈ʒu�������ʒu�ɕύX����
        transform.position = startPos + Vector3.up * 10f; ;

        //�v���C���[�̌������i0, 0, 0�j�ɕύX����
        transform.rotation = Quaternion.identity;

        //HPManager�̃R���|�[�l���g���擾
        var status = GetComponent<HPManager>();

        //recovery()�֐����Ăяo��
        status.Recovery();

        //�R���g���[���[��L����
        controller.enabled = true;

        ////////////////////////////////
        //�R�C���Ɋւ�����̃��Z�b�g//
        ////////////////////////////////

        //�l���������O�ɂ���
        coinNumber = 0;

        //�R�C���𕜊�������
        coinManager1.Revival();
        coinManager2.Revival();
    }

    ////////////////////////////////////////////////////////////////////////
    //���F���g�����|�����ɐG�ꂽ�ۂɁA�W�����v�́~�R������ɔ�΂����֐�//
    ////////////////////////////////////////////////////////////////////////
    public void YellowTrampoline()
    {
        //�g�����|����SE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Trampoline);
        
        //��ɔ�΂�
        moveDirection.y = jump * 3;
    }

    ////////////////////////////////////////////////////////////////////////////
    //����Cube�ɐG�ꂽ�ۂɁA�v���C���[�̍s�����~�߂āA�N���A��ʂ�\������֐�//
    ////////////////////////////////////////////////////////////////////////////
    public void WhiteGoal() 
    {
        ////////////////////////////
        //�v���C���[�̓������~�߂�//
        ////////////////////////////
        
        controller.enabled = false;     //�R���g���[���[�𖳌���

        moveDirection = Vector3.zero;   //�ړ��������Z�b�g

        ////////////////////////
        //�}�E�X�J�[�\���̉���//
        ////////////////////////

        // �}�E�X�J�[�\����\������
        Cursor.visible = true;

        //�}�E�X�J�[�\���̃��b�N����������
        Cursor.lockState = CursorLockMode.None;

        ////////////////////////////////////////////
        //�J������؂�ւ��āA�L�����o�X��\������//
        ////////////////////////////////////////////

        //BGM���~�߂�
        SoundManager.instance.StopBGM(SoundManager.BGM.Game_BGM);

        //�N���ASE��炷
        SoundManager.instance.PlaySE(SoundManager.SE.Clear);

        //���C���J������OFF�ɂ��āA�N���A�J������ON�ɂ���
        mainCamera.enabled = false;
        clearCamera.enabled = true;

        //�N���A�L�����o�X��\������
        Canvas.SetActive(true);
    }

    //////////////////////////////////////////////////////////
    //���ԃS�[���ɐG�ꂽ�ۂɁA�X�^�[�g�ʒu�ɋ����ړ�����֐�//
    //////////////////////////////////////////////////////////
    public void WhiteReturn()
    {
        ////////////////////////////
        //�v���C���[�̓������~�߂�//
        ////////////////////////////

        controller.enabled = false;     //�R���g���[���[�𖳌���

        moveDirection = Vector3.zero;   //�ړ��������Z�b�g

        ////////////////////////////////////////////////////////
        //�v���C���[���X�^�[�g�n�_�֑���A�R���g���[����L����//
        ////////////////////////////////////////////////////////

        //�v���C���[�̈ʒu�������ʒu�ɕύX����
        transform.position = startPos + Vector3.up * 10f; ;

        //�v���C���[�̌������i0, 0, 0�j�ɕύX����
        transform.rotation = Quaternion.identity;

        //HPManager�̃R���|�[�l���g���擾
        var status = GetComponent<HPManager>();

        //recovery()�֐����Ăяo��
        status.Recovery();

        //�R���g���[���[��L����
        controller.enabled = true;
    }

    ////////////////////////////////////////
    //HP���O�ɂȂ����ۂɁA�Ăяo�����֐�//
    ////////////////////////////////////////
    public void HP_Death() 
    {
        ////////////////////////////
        //�v���C���[�̓������~�߂�//
        ////////////////////////////

        controller.enabled = false;     //�R���g���[���[�𖳌���

        moveDirection = Vector3.zero;   //�ړ��������Z�b�g

        ////////////////////////////////////////////////////////
        //�v���C���[���X�^�[�g�n�_�֑���A�R���g���[����L����//
        ////////////////////////////////////////////////////////

        //�v���C���[�̈ʒu�������ʒu�ɕύX����
        transform.position = startPos + Vector3.up * 10f; ;

        //�v���C���[�̌������i0, 0, 0�j�ɕύX����
        transform.rotation = Quaternion.identity;

        //�A�j���[�^�[��Bool�^�p�����[�^�uDie�v�� false �ɂ���B
        animator.SetBool("Death", false);

        //HPManager�̃R���|�[�l���g���擾
        var status = GetComponent<HPManager>();

        //recovery()�֐����Ăяo��
        status.Recovery();

        //�R���g���[���[��L����
        controller.enabled = true;


        ////////////////////////////////
        //�R�C���Ɋւ�����̃��Z�b�g//
        ////////////////////////////////

        //�l���������O�ɂ���
        coinNumber = 0;

        //�R�C���𕜊�������
        coinManager1.Revival();
        coinManager2.Revival();
    }

    ////////////////////////////////////////
    //�R�C�����l�������ۂɌĂяo�����֐�//
    ////////////////////////////////////////
    public void CoinPlus() 
    {
        //�R�C��SE�𗬂�
        SoundManager.instance.PlaySE(SoundManager.SE.Coin);

        //�l�������𑝂₷
        coinNumber++;
    }

    ////////////////////////////////////////
    //�R�C�����Q���ȏ゠�邩�ǂ������肷��//
    ////////////////////////////////////////
    public bool Judgement_Coin() 
    {
        //�R�C�����Q���������Ă����true��Ԃ�
        return (coinNumber == 2);
    }
}