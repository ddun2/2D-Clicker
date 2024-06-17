using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyMovement : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sprite;

    private float speedX;
    private float speedY;
    private float delay;

    bool isWalking = false;
    bool isWandering = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
        transform.Translate(speedX, speedY, 0f);
    }

    IEnumerator Wander()
    {
        delay = 5f;

        speedX = Random.Range(-1f, 1f);
        speedY = Random.Range(-1f, 1f);

        isWandering = true;

        yield return new WaitForSeconds(delay);

        isWalking = true;
        animator.SetBool("isWalk", true);

        yield return new WaitForSeconds(delay);

        isWalking = false;
        animator.SetBool("isWalk", false);

        isWandering = false;
    }
}
