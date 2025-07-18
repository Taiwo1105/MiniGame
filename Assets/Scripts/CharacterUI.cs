using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    public Text nameText;
    public Slider healthBar;

    public void SetName(string characterName)
    {
        if (nameText != null)
        {
            nameText.text = characterName;
        }
    }

    public void SetHealth(int current, int max)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = max;
            healthBar.value = current;
        }
    }
}
