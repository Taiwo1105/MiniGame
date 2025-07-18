using UnityEngine;
using System.Collections;

public class Monster : Character
{
    public override void Attack(Character target)
    {
        SetState(new AttackState());

        SimpleAttack attack = new SimpleAttack(12);
        attack.Execute(this, target);

        StartCoroutine(AttackMotion(Vector3.left));
    }

    private IEnumerator AttackMotion(Vector3 direction)
    {
        Vector3 originalPos = transform.position;
        Vector3 targetPos = originalPos + direction * 0.5f;
        float elapsed = 0f, duration = 0.2f;
        float shakeMagnitude = 0.05f;  // Amount of shake

        // Move forward with shake effect
        while (elapsed < duration)
        {
            float t = elapsed / duration;
            Vector3 basePos = Vector3.Lerp(originalPos, targetPos, t);

            // Shake offset - random small jitter on X and Y
            Vector3 shakeOffset = new Vector3(
                Random.Range(-shakeMagnitude, shakeMagnitude),
                Random.Range(-shakeMagnitude, shakeMagnitude),
                0);

            transform.position = basePos + shakeOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset elapsed for moving back
        elapsed = 0f;

        // Move back smoothly without shake
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(targetPos, originalPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        // Ensure position resets exactly
        transform.position = originalPos;

        SetState(new IdleState());
    }
}

