using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

//�v���C���[��HP���Ǘ�����X�N���v�g
public class HPManager : MonoBehaviour
{
    //////////////////////////////
    //HP���O�ɂȂ������Ɉ������//
    //////////////////////////////
    
    //HP���O�ɂȂ������̃A�j���[�V����
    Animator animator;

    //UnityEvent�F�֐��̎Q�Ƃ��R�ێ����Ĉ�ĂɎ��s�ł���Q�ƌ^
    public UnityEvent onDieCallback = new UnityEvent();

    //////////////////
    //HP�Ɋւ�����//
    //////////////////

    public int life = 100; //�ő�HP��
    public Slider hpBar;   //HP�o�[

    ////////////////
    //�X�^�[�g�֐�//
    ////////////////
    void Start()
    {
        //�A�j���[�^�[�R���|�[�l���g���擾
        animator = GetComponent<Animator>();

        //HP�o�[�̏�����
        if (hpBar != null)
        {
            hpBar.value = life;
        }
    }

    ////////////////////////////////
    //�w�肵���_���[�W��^����֐�//
    ////////////////////////////////
    public void Damage(int damage)
    {
        ////////////////
        //HP�̒l�̊Ǘ�//
        ////////////////
        
        //HP���O�ȉ��̏ꍇ�A�������Ȃ�
        if (life <= 0) return;

        //HP���O�ȏ�̏ꍇ�A
        life -= damage;

        //�_���[�WSE�𗬂�
        SoundManager.instance.PlaySE(SoundManager.SE.Damage);

        ////////////////
        //HP�o�[�̊Ǘ�//
        ////////////////

        //HP�o�[���O�ł͂Ȃ��ꍇ
        if (hpBar != null)
        {
            //HP��ݒ肷��
            hpBar.value = life;
        }

        //HP���O�̏ꍇ
        if (life <= 0)
        {
            //Death�֐����Ăяo��
            Death();
        }
    }

    //////////////////////
    //HP��S�񕜂���֐�//
    //////////////////////
    public void Recovery() 
    {
        life = 100;
        hpBar.value = life;
    }

    //////////////////////////////////////////
    //HP���O�ȉ��ɂȂ������ɌĂяo�����֐�//
    //////////////////////////////////////////
    void Death()
    {
        //�A�j���[�^�[��Bool�^�p�����[�^�uDie�v��true�ɂ���B
        animator.SetBool("Death", true);

        //�L�����N�^�[���Ƃ̌ŗL�̏���
        onDieCallback.Invoke();

        //Player��PlayerManager�R���|�[�l���g���擾
        PlayerManager player = GetComponent<PlayerManager>();

        //PlayerManager��HP_Death�֐����Ăяo��
        player.HP_Death();
    }
}