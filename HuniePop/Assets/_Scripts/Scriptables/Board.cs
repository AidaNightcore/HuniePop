using UnityEngine;

public class Board : MonoBehaviour
{
    public int width; 
    public int height;
    public GameObject tilePrefab; 
    private BackgroundTile[,] allTiles; 
    public GameObject[] tokens;
    public GameObject[,] allTokens;
    public int offSet; 
    
    void Start()
    {
        allTiles = new BackgroundTile[width, height];
        allTokens = new GameObject[width, height];
        SetUp();
    }
    private void SetUp()
    {
        for (int  i = 0;  i < width;  i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 tempPos = new Vector2(i, j+offSet);
                GameObject backgroundTile = Instantiate(tilePrefab, tempPos,Quaternion.identity) as GameObject;
                backgroundTile.transform.parent = this.transform;
                backgroundTile.name = "(" + i + "," + j+")";
                int tokensToUse = Random.Range(0, tokens.Length);
                GameObject token  = Instantiate(tokens[tokensToUse], tempPos, Quaternion.identity);
                
                token.GetComponent<TokenBehaviour>().row = j;
                token.GetComponent<TokenBehaviour>().column = i;
                token.transform.parent = this.transform;
                
                allTokens[i, j] = token;
            }
        }
    }
}
