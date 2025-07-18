using UnityEngine;

public interface ICharacterState
{
    void Enter(Character character);
    void Execute(Character character);
    void Exit(Character character);
}

public class IdleState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log(character.characterName + " is idle.");
    }
    public void Execute(Character character) { }
    public void Exit(Character character) { }
}

public class AttackState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log(character.characterName + " starts attacking.");
    }
    public void Execute(Character character) { }
    public void Exit(Character character) { }
}

public class DeadState : ICharacterState
{
    public void Enter(Character character)
    {
        Debug.Log(character.characterName + " has died.");
        character.StartCoroutine(DestroyAfterDelay(character, 1.5f)); // Delay destruction by 1.5 seconds
    }

    public void Execute(Character character) { }
    public void Exit(Character character) { }

    private System.Collections.IEnumerator DestroyAfterDelay(Character character, float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject.Destroy(character.gameObject);
    }
}
