using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //public GameObject[] goalObjs;
    public List<GameObject> goalObjs;
    public GameObject goalObj;
    public GameObject[] mazeHazards;
    public GameObject[] droppers;


    public enum GoalType
    {
        drop,key,click,maze,dialog,none,sort

    }

    public GoalType type;

    public bool complete;
    public bool failed;

    public KeyBar keyBar;
    public Drop drop;
    public VisualNovel visualNovel;
    GameData data;
    TMP_Text taskText;
    TMP_Text timeText;
    TMP_Text dayText;

    public bool extraStress = false;

    float timeTimer = 0;
    float setupTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        switch (type)
        {
            case GoalType.drop:
                goalObj = GameObject.FindGameObjectWithTag("Goal");
                drop = goalObj.GetComponent<Drop>();
                break;
            case GoalType.key:
                goalObj = GameObject.FindGameObjectWithTag("Goal");
                keyBar = goalObj.GetComponent<KeyBar>();
                break;
            case GoalType.click:
                goalObjs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal"));
                break;
            case GoalType.maze:
                goalObj = GameObject.FindGameObjectWithTag("Goal");
                drop = goalObj.GetComponent<Drop>();
                mazeHazards = GameObject.FindGameObjectsWithTag("Hazard");
                //drop = goalObj.GetComponent<Drop>();
                break;
            case GoalType.dialog:
                goalObj = GameObject.FindGameObjectWithTag("Goal");
                visualNovel = goalObj.GetComponent<VisualNovel>();
                break;
            case GoalType.none:
                break;
            case GoalType.sort:
                goalObjs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal"));
                droppers = GameObject.FindGameObjectsWithTag("Drop");
                break;
        }
        GameObject temp = GameObject.FindGameObjectWithTag("TaskText");
        if (temp != null)
        {
            taskText = temp.GetComponent<TMP_Text>();
        }
        temp = GameObject.FindGameObjectWithTag("CurrTime");
        if (temp != null)
        {
            timeText = temp.GetComponent<TMP_Text>();
        }
        temp = GameObject.FindGameObjectWithTag("DayText");
        if (temp != null)
        {
            dayText = temp.GetComponent<TMP_Text>();
        }
        data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
        //data = Resources.Load<GameData>("MainData");

        //reset data if main menu
        temp = GameObject.FindGameObjectWithTag("MainMenu");
        if (temp != null && data != null)
        {
            data.isMorning = true;
            data.min = 30;
            data.hour = 7;
            data.stressLevel = 0;
            data.morningTasks = 3;
            data.workTasks = 18;
            data.day = 1;
        }

        //goalObj = GameObject.FindGameObjectsWithTag("Goal");
        //if(goalObj[0].layer == 5 && !clickGoal)
        //{
        //    keyBar = goalObj[0].GetComponent<KeyBar>();
        //    keyGoal = true;
        //}
        //else if(!clickGoal)
        //{
        //    drop = goalObj[0].GetComponent<Drop>();
        //        dropGoal = true;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(data == null)
        {
            data = GameObject.FindGameObjectWithTag("Data").GetComponent<DataManager>().data;
            data.isMorning = true;
            data.min = 30;
            data.hour = 7;
            data.stressLevel = 0;
            data.morningTasks = 3;
            data.workTasks = 18;
            data.day = 1;
        }
        if(!data.isMorning && taskText != null)
        {
            taskText.text = "Tasks: " + data.workTasks;
        }
        else if(taskText != null)
        {
            taskText.text = "Tasks: " + data.morningTasks;
        }

        if (dayText != null)
        {
            dayText.text = "Day: " + data.day;
        }

        if (timeText != null)
        {
            timeTimer += Time.deltaTime;
            if(timeTimer >= 0.625f)
            {
                timeTimer = 0;
                data.AddMin(1);
            }

            if(data.min >= 60)
            {
                data.AddHour(1);
                data.AddMin(-60);
            }

            if (data.hour >= 10)
            {
                timeText.text = "Time: " + data.hour;
            }
            else
            {
                timeText.text = "Time: 0" + data.hour;
            }
            if(data.min >= 10)
            {
                timeText.text += ":" + data.min;
            }
            else
            {
                timeText.text += ":0" + data.min;
            }
        }
        
        if (type == GoalType.none || setupTime >= 0)
        {
            setupTime -= Time.deltaTime;
            return;
        }


        switch(type)
        {
            case GoalType.drop:
                complete = drop.complete;
                failed = drop.failed;
                break;
            case GoalType.key:
                complete = keyBar.complete;
                failed = keyBar.failed;
                break;
            case GoalType.click:
                goalObjs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal"));
                for (int g = 0; g < goalObjs.Count; g++)
                {
                    if (goalObjs[g] == null)
                    {
                        goalObjs.Remove(goalObjs[g]);
                    }
                }
                if (goalObjs.Count == 0)
                {
                    complete = true;
                }
                else
                {
                    complete = false;
                }
                break;
            case GoalType.maze:
                complete = drop.complete;
                foreach(GameObject h in mazeHazards)
                {
                    Drop hD = h.GetComponent<Drop>();
                    if (hD.failed == true)
                    {
                        failed = hD.failed;
                    }
                }
                break;
            case GoalType.dialog:
                complete = visualNovel.complete;
                break;
            case GoalType.sort:
                goalObjs = new List<GameObject>(GameObject.FindGameObjectsWithTag("Goal"));
                for (int g = 0; g < goalObjs.Count; g ++)
                {
                    if (goalObjs[g] == null)
                    {
                        goalObjs.Remove(goalObjs[g]);
                    }
                }
                if (goalObjs.Count == 0)
                {
                    complete = true;
                }
                else
                {
                    complete = false;
                }
                //droppers = GameObject.FindGameObjectsWithTag("Drop");
                foreach (GameObject h in droppers)
                {
                    Drop hD = h.GetComponent<Drop>();
                    if (hD.failed == true)
                    {
                        failed = hD.failed;
                    }
                }
                break;
        }

        if(complete)
        {
            if(data.isMorning)
            {
                data.morningTasks--;
                data.AddStress(-4) ;
                GoToFridge();
            }
            else
            {
                data.workTasks--;
                data.AddStress(-4);
                GoToDesk();
            }
        }
        if (failed)
        {
            if (data.isMorning)
            {
                data.morningTasks--;
                if(extraStress)
                {
                    data.AddStress(10);
                }
                GoToFridge();
            }
            else
            {
                data.workTasks--;
                if (extraStress)
                {
                    data.AddStress(10);
                }
                GoToDesk();
            }
        }

        if(data.morningTasks == 0 && data.isMorning)
        {
            data.hour = 9;
            data.min = 0;
            data.isMorning = false;
            data.morningTasks += 3;
            GoToDesk();
        }
        if (data.workTasks == 0 && !data.isMorning)
        {
            data.hour = 8;
            data.min = 0;
            data.isMorning = true;
            data.day += 1;
            data.workTasks += 24 + data.day;
            if(data.stressLevel < 10)
            {
                data.AddStress(-data.stressLevel);
            }
            else
            {
                data.AddStress(-10);
            }
            GoToFridge();
        }

        if(data.hour == 5 && !data.isMorning)
        {
            data.hour = 8;
            data.min = 0;
            data.isMorning = true;
            data.AddStress(4 * data.workTasks);
            data.day += 1;
            data.workTasks += 24 + data.day;
            GoToFridge();
        }
        if (data.hour == 8 && data.min >= 40 && data.isMorning)
        {
            data.hour = 9;
            data.min = 0;
            data.isMorning = false;
            data.AddStress(4 * data.morningTasks);
            data.morningTasks += 3;
            GoToDesk();
        }
        //
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToDesk()
    {
        data.isMorning = false;
        SceneManager.LoadScene("Desk");
    }
    public void GoToFridge()
    {
        SceneManager.LoadScene("Fridge");
    }
    public void Quit()
    {
        Application.Quit();
    }








}
