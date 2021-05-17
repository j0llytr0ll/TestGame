using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDObject : MonoBehaviour
{
    public GameObject gameManager;
    List<Vector3> list;
    int i = 0;   



    public void StartPlayer()
    {       
        list = gameManager.GetComponent<GameManager>().twoDList;       
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {       
        while (i < list.Count)
        {
            GameManager.stopwatchStatus = true;
            while (transform.position != list[i])
            {
                transform.position = Vector3.MoveTowards(transform.position, list[i], GameManager.speed * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }
            GameManager.milliseconds = 0;
            GameManager.seconds = 0;
            GameManager.minutes = 0;
            GameManager.stopwatchStatus = false;
            i++;
            yield return new WaitForSeconds(0);
        }
        gameManager.GetComponent<GameManager>().EndMove();
    }
   
}
