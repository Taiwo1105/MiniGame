using UnityEngine;

public enum CharacterType
{
    Hero,
    Monster
}

public static class CharacterFactory
{
    public static Character CreateCharacter(CharacterType type, string name)
    {
        GameObject characterObj = new GameObject(name);
        Character character = null;

        switch (type)
        {
            case CharacterType.Hero:
                character = characterObj.AddComponent<Hero>();
                break;

            case CharacterType.Monster:
                character = characterObj.AddComponent<Monster>();
                break;
        }

        character.characterName = name;

        // Create dummy UI so Start() won't crash
        GameObject uiObj = new GameObject(name + "_UI");
        CharacterUI ui = uiObj.AddComponent<CharacterUI>();
        character.ui = ui;

        return character;
    }
}
