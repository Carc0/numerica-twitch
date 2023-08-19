using System.Collections;
using UnityEngine;


public class HojaController : MonoBehaviour
{
    private Animator animator;

    private bool isCreated = false;
    private bool isAlive = false;
    private bool canDie = false;

    public int lives;

    public float damageSeconds = 60.0f;
    private float time;

    public float DamageSeconds { get => damageSeconds; set => damageSeconds = value; }
    public bool CanDie { get => canDie; set => canDie = value; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAlive || lives == 0) return;

        time += Time.deltaTime;

        if (time >= damageSeconds)
        {
            time = 0;
            SetDamage();
        }
    }

    public bool SetWater()
    {
        if (lives > 4) return false;

        if (!isCreated)
        {
            isAlive = true;
            isCreated = true;
            lives = 0;

            gameObject.SetActive(true);
        }

        if (!isAlive) return false;

        animator.SetTrigger("SetWater");

        time = 0;
        lives++;

        return true;
    }

    private void SetDamage()
    {
        lives--;

        lives = Mathf.Max(0, lives);

        if (lives == 0 && CanDie) 
            isAlive = false;

        animator.SetTrigger("SetDamage");
    }
}