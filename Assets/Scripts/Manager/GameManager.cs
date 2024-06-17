using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public float jelly;
    public int gold;

    public TextMeshProUGUI jellyText;
    public TextMeshProUGUI goldText;

    public RuntimeAnimatorController[] animatorController;

    public JellySO[] jellySO;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void LateUpdate()
    {
        jellyText.text = string.Format("{0:n0}", Mathf.SmoothStep(float.Parse(jellyText.text), jelly, 0.5f));
        goldText.text = string.Format("{0:n0}", Mathf.SmoothStep(float.Parse(goldText.text), gold, 0.5f));
    }

    public void ChangeAnimator(Animator animator, int level)
    {
        animator.runtimeAnimatorController = animatorController[level - 1];
    }
}
