using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyDestroy : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
