using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public Hero hero;
    public Monster monster;
    public float delayBetweenAttacks = 1.5f;

    void Start()
    {
        StartCoroutine(BattleLoop());
    }

    IEnumerator BattleLoop()
    {
        while (hero != null && monster != null)
        {
            if (monster.CurrentHealth() <= 0 || hero.CurrentHealth() <= 0)
                yield break;

            // Hero attacks
            hero.Attack(monster);
            yield return new WaitForSeconds(delayBetweenAttacks);

            if (monster == null || monster.CurrentHealth() <= 0)
                yield break;

            // Monster attacks
            monster.Attack(hero);
            yield return new WaitForSeconds(delayBetweenAttacks);
        }
    }
}
