using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxCounter : MonoBehaviour
{
    public static FoxCounter instance;
    public int foxAmount;
    [SerializeField] private int foxesToGather;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject.transform.parent.gameObject);
            Debug.LogWarning($"There was more than one {GetType().Name}, deleting extra.");
        }
    }
    public void AddFox()
    {
        foxAmount++;

        if (foxAmount >= foxesToGather)
        {
            GetComponent<GetHorseResult>().Execute();
        }
    }
}
