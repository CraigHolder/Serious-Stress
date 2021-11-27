using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public GameData data;

    // Start is called before the first frame update
    void Start()
    {
        data = Resources.Load<GameData>("MainData");
        DontDestroyOnLoad(this.gameObject);
    }
}
