using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : Character
{
    public override void Attack(Character target)
    {
        SetState(new AttackState());

        // Create combo attack
        ComboAttack combo = new ComboAttack();
        combo.Add(new SimpleAttack(10));
        combo.Add(new SimpleAttack(5));

        // Start visual + logic execution
        StartCoroutine(PerformComboAttack(combo, target, Vector3.right));
    }

    private IEnumerator PerformComboAttack(ComboAttack combo, Character target, Vector3 direction)
    {
        foreach(AttackComponent attack in combo.attacks)

        {
            attack.Execute(this, target);
            yield return StartCoroutine(AttackMotion(direction));
        }

        SetState(new IdleState());
    }

    private IEnumerator AttackMotion(Vector3 direction)
    {
        Vector3 originalPos = transform.position;
        Vector3 targetPos = originalPos + direction * 0.3f; // Slight move
        float elapsed = 0f, duration = 0.1f;

        // Forward motion
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(originalPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Backward motion
        elapsed = 0f;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(targetPos, originalPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos; // Just in case
    }
}
