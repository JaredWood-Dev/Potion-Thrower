using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int numberOfLevels;
    public GameObject mainMenu;
    public GameObject levelSelect;

    [Header("Level Array Parameters")] 
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float distBetweenCells;
    public float distBetweenRows;
    public Vector2 initialLocation;
    public GameObject cellPrefab;

    public void Start()
    {
        numberOfLevels = SceneManager.sceneCount;
        
        DisplayMenu();
        GenerateLevelArray();
    }

    public void DisplayLevels()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void DisplayMenu()
    {
        mainMenu.SetActive(true);
        levelSelect.SetActive(false);
    }

    public void LoadLevel(int level)
    {
        //Offset to account for main menu scene
        SceneManager.LoadScene(level + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void GenerateLevelArray()
    {
        int rowNum = 0;
        int columnNum = 0;
        for (int i = 0; i < numberOfLevels; i++)
        {
            if (initialLocation.x + columnNum * distBetweenCells > maxX)
            {
                rowNum--;
                columnNum = 0;
            }
            Vector2 cellPosition = initialLocation + new Vector2(columnNum * distBetweenCells, rowNum * distBetweenRows);
            var cell = Instantiate(cellPrefab, cellPosition,Quaternion.identity);
            cell.transform.SetParent(levelSelect.transform);
            cell.GetComponent<RectTransform>().anchoredPosition = cellPosition;
            cell.transform.GetChild(0).gameObject.GetComponent<Text>().text = (i + 1).ToString();
            var i1 = i;
            cell.GetComponent<Button>().onClick.AddListener(() => LoadLevel(i1));
            
            columnNum++;
        }
    }
}
