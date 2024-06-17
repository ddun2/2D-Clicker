using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sprite;
    private Jelly jellyInfo;

    private float speedX;
    private float speedY;
    private float delay;

    bool isWalking;
    bool isWandering;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        jellyInfo = GetComponent<Jelly>();

        isWalking = false;
        isWandering = false;
    }

    private void Update()
    {
        //jellyInfo.exp += Time.deltaTime;

        LevelUp();
    }

    private void FixedUpdate()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }

        if (isWalking)
        {
            Move();
        }
    }

    private void Move()
    {
        // ��������Ʈ �¿� ������
        sprite.flipX = speedX < 0;

        // ���� �̵�
        transform.Translate(new Vector2(speedX, speedY));
    }

    // ���� Ŭ�� ��
    private void OnMouseDown()
    {
        // �̵��� ���߰� Ŭ�� �ִϸ��̼� ���
        isWalking = false;
        animator.SetBool("isWalk", false);
        animator.SetTrigger("onClick");

        // ���� ��ȭ �߰�
        GameManager.Instance.jelly += (jellyInfo.id + 1) * jellyInfo.level;

        // ����ġ �߰�
        jellyInfo.exp++;

        LevelUp();
    }

    private void LevelUp()
    {
        // �ʿ� ����ġ�� �Ѿ�� ������
        if (jellyInfo.exp >= jellyInfo.level * jellyInfo.requiredExp)
        {
            jellyInfo.level++;

            // �ִ� 3�������� ũ�� ����
            if (jellyInfo.level <= 3)
            {
                GameManager.Instance.ChangeAnimator(animator, jellyInfo.level);
            }
        }
    }

    IEnumerator Wander()
    {
        // delay ��ŭ ��� �� ���� �������� �̵� �ݺ�
        delay = 3f;

        speedX = Random.Range(-1f, 1f) * Time.deltaTime;
        speedY = Random.Range(-1f, 1f) * Time.deltaTime;

        isWandering = true;

        yield return new WaitForSeconds(delay);

        isWalking = true;
        animator.SetBool("isWalk", true);

        yield return new WaitForSeconds(delay);

        isWalking = false;
        animator.SetBool("isWalk", false);

        isWandering = false;
    }    

    private void OnTriggerEnter2D(Collider2D boader)
    {
        if (boader.gameObject.CompareTag("LeftRight"))
        {
            speedX = -speedX;
            Debug.Log("�¿�");
        }
        else if (boader.gameObject.CompareTag("TopBottom"))
        {
            speedY = -speedY;
            Debug.Log("����");
        }
    }
}
