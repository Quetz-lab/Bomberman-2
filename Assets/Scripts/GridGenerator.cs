using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class GridGenerator : MonoBehaviour
{

    const int Col = 13;
    const int Row = 13;
    const int Col_off = 1;
    const int Row_off = 1;

    [SerializeField] GameObject UnbreakableWallPref;
    [SerializeField] GameObject TheOtherWallPref;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateTheOtherWalls();
        GenerateUnbreakableWalls();
    }

    void GenerateTheOtherWalls()
    {
        bool generateThisTile = false;

        generateThisTile = GenerateSpecialFirstAndLastBreakables(generateThisTile, 0);
        generateThisTile = GenerateSpecialSecondFirstAndLast(generateThisTile, 1);

        for (int i = 2; i < Row - 1; i++) 
        {
            for (int j = 0; j < Col; j++) 
            {
                if (generateThisTile)
                {
                    GameObject newBreakable = Instantiate(TheOtherWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * Col_off, 0, -Row * Row_off);
                }
                generateThisTile = !generateThisTile;
            } 
        }
        generateThisTile = GenerateSpecialFirstAndLastBreakables(generateThisTile, Row - 1);
        generateThisTile = GenerateSpecialSecondFirstAndLast(generateThisTile, Row - 2);
    }

    private bool GenerateSpecialSecondFirstAndLast(bool generateThisTile, int row)
    {
        for (int j = 0; j < Col; j++)
        {
            if (generateThisTile)
            {
                if (j != 0 && j != Col - 1)
                {
                    GameObject newBreakable = Instantiate(TheOtherWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * Col_off, 0, -row * Row_off);
                }
            }
            generateThisTile = !generateThisTile;
        }

        return generateThisTile;
    }

    private bool GenerateSpecialFirstAndLastBreakables(bool generateThisTile, int row)
    {
        for (int j = 0; j < Col; j++)
        {
            if (generateThisTile)
            {
                if (j != 1 && j == Col - 2)
                {
                    GameObject newBreakable = Instantiate(TheOtherWallPref, gameObject.transform);
                    newBreakable.transform.localPosition = new Vector3(j * Col_off, 0, -row * Row_off);
                }


            }
            generateThisTile = !generateThisTile;
        }

        return generateThisTile;
    }

    void GenerateUnbreakableWalls()
    {  
        for (int i = 0;i < Row;i+= 2)
        {
            bool generateThisTile = false;
            for (int j = 0; j < Col; j++)
            {
                if (generateThisTile)
                {
                    GameObject newUnbreakable = Instantiate(UnbreakableWallPref, gameObject.transform);
                    newUnbreakable.transform.localPosition = new Vector3(j * Col_off, 0, -i * Row_off);
                }
                generateThisTile = !generateThisTile;
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
