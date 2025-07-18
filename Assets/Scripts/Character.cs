using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public string characterName;
    public CharacterUI ui;

    protected int currentHealth = 100;
    protected int maxHealth = 100;

    protected Animator animator; // Animator reference
    private ICharacterState currentState;

    public virtual void Start()
    {
        animator = GetComponent<Animator>(); // Initialize animator

        if (ui != null)
        {
            ui.SetName(characterName);
            ui.SetHealth(currentHealth, maxHealth);
        }

        SetState(new IdleState());
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (ui != null)
            ui.SetHealth(currentHealth, maxHealth);

        if (animator != null)
            animator.SetTrigger("Hit"); // Trigger hit animation

        if (currentHealth <= 0)
        {
            SetState(new DeadState());

            if (animator != null)
                animator.SetTrigger("Die"); // Trigger death animation
        }
    }

    public int CurrentHealth() => currentHealth;

    public void SetState(ICharacterState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }

    void Update()
    {
        currentState?.Execute(this);
    }

    public abstract void Attack(Character target); // Implement in derived classes
}
