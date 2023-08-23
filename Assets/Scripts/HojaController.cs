using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HojaController : MonoBehaviour
{
    [SerializeField] private PlantEnums.HojaType hojaType;

    private Animator animator;

    private bool isCreated = false;
    private bool isAlive = false;
    private bool canDie = false;

    public int lives;

    private int damageSeconds = 60;
    private float currentTime;

    public int DamageSeconds { get => damageSeconds; set => damageSeconds = value; }
    public bool CanDie { get => canDie; set => canDie = value; }


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (!isAlive || lives == 0) return;

        currentTime += Time.deltaTime;

        if (currentTime >= damageSeconds)
        {
            currentTime = 0;
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

        currentTime = 0;
        lives++;

        return true;
    }

    private void SetDamage()
    {
        lives--;

        lives = Mathf.Max(0, lives);

        if (lives == 0 && canDie) 
            isAlive = false;

        animator.SetTrigger("SetDamage");
    }
}