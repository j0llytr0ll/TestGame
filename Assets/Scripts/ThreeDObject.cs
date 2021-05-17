using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ThreeDObject : MonoBehaviour, IPointerClickHandler
{
    public Text error;
    public GameObject gameManager;
    List<Vector3> list;
    int i = 0;
    public void OnPointerClick(PointerEventData eventData)
    {
        error.text = "";
        list = gameManager.GetComponent<GameManager>().threeDList;
        StartCoroutine(Move());
    }

    void OnCollisionEnter()
    {
        error.text = "Error: crashed";
        StopAllCoroutines();
    }

    IEnumerator Move()
    {
        while (i < list.Count)
        {
            while (transform.position != list[i])
            {
                transform.position = Vector3.MoveTowards(transform.position, list[i], GameManager.speed * Time.deltaTime);
                yield return new WaitForSeconds(0);
            }
            i++;
            yield return new WaitForSeconds(0);
        }
    }
}
