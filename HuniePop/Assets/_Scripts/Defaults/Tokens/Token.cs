using UnityEngine;

[CreateAssetMenu(fileName = "Token", menuName = "Scriptable Objects/Token")]
public class Token : ScriptableObject
{
    private Sprite sprite;
    private int score;
    private float spawnRate; 
}

