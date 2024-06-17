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
        // 스프라이트 좌우 뒤집기
        sprite.flipX = speedX < 0;

        // 젤리 이동
        transform.Translate(new Vector2(speedX, speedY));
    }

    // 젤리 클릭 시
    private void OnMouseDown()
    {
        // 이동을 멈추고 클릭 애니메이션 재생
        isWalking = false;
        animator.SetBool("isWalk", false);
        animator.SetTrigger("onClick");

        // 젤리 재화 추가
        GameManager.Instance.jelly += (jellyInfo.id + 1) * jellyInfo.level;

        // 경험치 추가
        jellyInfo.exp++;

        LevelUp();
    }

    private void LevelUp()
    {
        // 필요 경험치를 넘어가면 레벨업
        if (jellyInfo.exp >= jellyInfo.level * jellyInfo.requiredExp)
        {
            jellyInfo.level++;

            // 최대 3레벨까지 크기 변경
            if (jellyInfo.level <= 3)
            {
                GameManager.Instance.ChangeAnimator(animator, jellyInfo.level);
            }
        }
    }

    IEnumerator Wander()
    {
        // delay 만큼 대기 후 랜덤 방향으로 이동 반복
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
            Debug.Log("좌우");
        }
        else if (boader.gameObject.CompareTag("TopBottom"))
        {
            speedY = -speedY;
            Debug.Log("상하");
        }
    }
}
