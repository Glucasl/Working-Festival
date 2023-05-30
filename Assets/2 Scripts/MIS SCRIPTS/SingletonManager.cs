using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Usamos el patron Singleton para guardar variables entre escenas
public class SingletonManager : MonoBehaviour
{
 public static SingletonManager singleton;

    //Si el singleton es null le decimos que use el que tenemos y en caso de que no destruimos el objeto
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

  
    //Las varaibles que queremos guardadas en el singleton con un set y get
    private int _contador ;
    public int Contador 
    {
        get { return _contador; }
        set { _contador = value; }
    }

    public int Score { get; set; }

    private int _ScoreGlobal;
    public int scoreGlobal
    {
        get { return _ScoreGlobal; }
        set { _ScoreGlobal = value; }
    }

    private float _timeDay = 0.28f;
    public float timeDay
    {
        get { return _timeDay; }
        set { _timeDay = value; }
    }

    private float _hambre = 100;
    public float HAMBRE
    {
        get { return _hambre; }
        set { _hambre = value; }
    }

    private float _sed = 100;
    public float SED
    {
        get { return _sed; }
        set { _sed= value; }
    }

    private float _vida =100;
    public float VIDA
    {
        get { return _vida; }
        set { _vida = value; }
    }
}
