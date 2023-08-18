using System.Collections;
using UnityEngine;


public class HojaController : MonoBehaviour
{
    private Animator animator;

    private bool isCreated;
    private bool isAlive;

    public int lives;

    public float damageSeconds = 60.0f;
    private float time;

    public float DamageSeconds { get => damageSeconds; set => damageSeconds = value; }


    private void Awake()
    {
        lives = 0;
        isCreated = false;

        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAlive) return;

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

            lives = 1;

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

        if (lives == 1) 
            isAlive = false;

        animator.SetTrigger("SetDamage");
    }
}