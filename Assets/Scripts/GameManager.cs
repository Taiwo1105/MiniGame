using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Hero hero;
    public Monster monster;

    private bool isHeroTurn = true;

    void Start()
    {
        // Create characters using the Factory Pattern
        hero = (Hero)CharacterFactory.CreateCharacter(CharacterType.Hero, "HeroKnight");
        monster = (Monster)CharacterFactory.CreateCharacter(CharacterType.Monster, "Wolf");

        StartCoroutine(NextTurn());
    }

    IEnumerator NextTurn()
    {
        while (hero != null && monster != null)
        {
            yield return new WaitForSeconds(1.5f);

            if (isHeroTurn)
                hero.Attack(monster);
            else
                monster.Attack(hero);

            isHeroTurn = !isHeroTurn;

            // Check win condition
            if (monster.CurrentHealth() <= 0)
            {
                Debug.Log("Hero wins!");
                yield break;
            }

            if (hero.CurrentHealth() <= 0)
            {
                Debug.Log("Monster wins!");
                yield break;
            }
        }
    }
}
