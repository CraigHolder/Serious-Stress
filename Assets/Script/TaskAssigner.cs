using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TaskAssigner : MonoBehaviour
{
    public enum MorningMiniGames
    {
        BrushingTeeth, PrepLunch, Breakfast, Laundry, TakeOutTrash
    }
    public enum WorkMiniGames
    {
        Maze, WriteSignatures, LiftBox, SortFiles
    }
    public MorningMiniGames nextMorningGame;
    public WorkMiniGames nextWorkGame;

    int morningRand;
    int workRand;

    GameData data;

    void OnMouseDown()
    {
        
        
        if (data.isMorning)
        {
            
            morningRand = Random.Range(0, 5);
            nextMorningGame = (MorningMiniGames)morningRand;
            switch (nextMorningGame)
            {
                //Morning
                case MorningMiniGames.BrushingTeeth:
                    SceneManager.LoadScene("BrushingTeeth");
                    data.AddStress(4);
                    break;
                case MorningMiniGames.PrepLunch:
                    SceneManager.LoadScene("PrepLunch");
                    data.AddStress(4);
                    break;
                case MorningMiniGames.Breakfast:
                    SceneManager.LoadScene("Breakfast");
                    data.AddStress(4);
                    break;
                case MorningMiniGames.Laundry:
                    SceneManager.LoadScene("Laundry");
                    data.AddStress(4);
                    break;
                case MorningMiniGames.TakeOutTrash:
                    SceneManager.LoadScene("Trash");
                    data.AddStress(4);
                    break;
                default:
                    SceneManager.LoadScene("BrushingTeeth");
                    data.AddStress(4);
                    break;
            }
        }
        else
        {
            
            workRand = Random.Range(0, 4);
            nextWorkGame = (WorkMiniGames)workRand;
            switch (nextWorkGame)
            {
                //Work
                case WorkMiniGames.Maze:
                    SceneManager.LoadScene("Maze");
                    data.AddStress(4);
                    break;
                case WorkMiniGames.WriteSignatures:
                    SceneManager.LoadScene("Write");
                    data.AddStress(4);
                    break;
                case WorkMiniGames.LiftBox:
                    SceneManager.LoadScene("LiftBox");
                    data.AddStress(4);
                    break;
                case WorkMiniGames.SortFiles:
                    SceneManager.LoadScene("SortFiles");
                    data.AddStress(4);
                    break;
                default:
                    SceneManager.LoadScene("SortFiles");
                    data.AddStress(4);
                    break;
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
