using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DATOSCAMBIOESCENA : MonoBehaviour
{
    public static DATOSCAMBIOESCENA instance;

    #region Generic Script

    private int _contador;
    private float _currentStamina;
    public float _currentThirst;
    public float _currentHunger;

    #endregion

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetMoney(int i)
    {
        _contador = i;
    }

    public int GetMoney()
    {
        return _contador;
    }

}
