using System.Collections.Generic;
using UnityEngine;

public abstract class AttackComponent
{
    public abstract void Execute(Character attacker, Character target);
}

public class SimpleAttack : AttackComponent
{
    private int damage;

    public SimpleAttack(int damage)
    {
        this.damage = damage;
    }

    public override void Execute(Character attacker, Character target)
    {
        Debug.Log(attacker.characterName + " deals " + damage + " damage!");
        target.TakeDamage(damage);
    }
}

public class ComboAttack : AttackComponent
{
    public List<AttackComponent> attacks = new List<AttackComponent>();

    public void Add(AttackComponent attack)
    {
        attacks.Add(attack);
    }

    public override void Execute(Character attacker, Character target)
    {
        foreach (var attack in attacks)
        {
            attack.Execute(attacker, target);
        }
    }
}