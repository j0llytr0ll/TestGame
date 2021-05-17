using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //������ ��������� ���� ��������
    public List<Vector3> twoDList;
    public List<Vector3> threeDList;

    //������ �� �������
    public GameObject twoDPlayer;
    public GameObject threeDPlayer;

    //���
    int x;
    int yz;

    //�������� ��������
    public static float speed = 500;   

    //����������
    public Text stopwatch;
    public static bool stopwatchStatus = false;
    public static int milliseconds = 0;
    public static int seconds = 0;
    public static int minutes = 0;

    //���������
    public Text speedometer;

    //�������� �� ������ ������
    bool firstTurnOn = true;

    //UI ������ �� ������
    public Button button;

    //��������� �������
    public GameObject enemy;

    private void Start()
    {
        speedometer.text = speed + " �/�";
    }
    public void ButtonClick()
    {
        button.interactable = false;
        if (firstTurnOn == true && twoDList.Count > 0)
        {
            twoDPlayer.GetComponent<TwoDObject>().StartPlayer();
            firstTurnOn = false;
        }
        else
        {
            x = Random.Range(50, 1390);
            yz = Random.Range(50, 1390);
            twoDList.Add(new Vector3(x, yz, 0));
            threeDList.Add(new Vector3(x, 51, yz));
            twoDPlayer.GetComponent<TwoDObject>().StartPlayer();
            firstTurnOn = false;
        }       
    }

    public void EndMove()
    {
        button.interactable = true;
        GetComponent<SaveLoadManager>().SaveGame();
    }

    void FixedUpdate()
    {
        if (stopwatchStatus == true)
        {
            milliseconds += 2;
            if (milliseconds == 100)
            {
                milliseconds = 0;
                seconds++;
                if (seconds == 60)
                {
                    seconds = 0;
                    minutes++;
                }
            }
            stopwatch.text = $"{minutes:D2}:{seconds:D2}:{milliseconds:D2}";
        }

    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < 5; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(50, 1390), 25, Random.Range(50, 1390));
            Instantiate(enemy, spawnPosition, enemy.transform.rotation);
        }
    }
}


