using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Scriptable Objects/Character")]
public class Character : ScriptableObject
{
    private string characterName;
    private int age; 
    // private Personality personality;
    private Sprite sprite;
    // private Dictionary<Gift> giftDictionary; 

    public Character()
    {
        
    }

    public string CharacterName => characterName;

    public int Age => age;

    public Sprite Sprite => sprite;
    
    
}

