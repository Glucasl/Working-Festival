using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

    
//El script general que lleva la mayoria de mecanicas que posee el player del juego en la escena principal
public class StatsManager : MonoBehaviour
{
    // Singleton
    public static StatsManager singleton;

    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }

    }

    //MiniJuegoLLuvia

    [Header("Comida")]
    public int comida = 0;
    [SerializeField] public Text _textcomida;
    [Header("Bebida")]
    public int bebida = 0;
    [SerializeField] public Text _textbebida;

    //Monedas

   [Header("Monedas")]

   [SerializeField] public Text _monedas;
   [SerializeField] public Text scoreText;
   

    //Hambre

   [Header("Hambre")]

    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hungerDeplationRate = 1f;
    public float _currentHunger;

    public float HungerPercent => _currentHunger / _maxHunger;

    //Sed

    [Header("Sed")]

    [SerializeField] private float _maxThirst = 100f;
    [SerializeField] private float _ThirstDeplationRate = 1f;
    public float _currentThirst;

    public float ThirstPercent => _currentThirst / _maxThirst;


    // Vida

    [Header("Vida")]

    [SerializeField] private float _maxStamina = 100f;
    [SerializeField] private float _staminaDeplationRate = 1f;
    [SerializeField] private float _staminaRechargeRate = 2f;
    [SerializeField] private float _staminaRechargeDelay = 1f;

    public float _currentStamina;
    private float _currentStaminaDelayCounter;
    public float StaminaPercent => _currentStamina / _maxStamina;

    public static UnityAction OnPlayerDied;

    // Incializamos las variables de comida, vida y sed
   private void Start()
    {
        _currentHunger = SingletonManager.singleton.HAMBRE;
        _currentStamina = SingletonManager.singleton.VIDA;
        _currentThirst = SingletonManager.singleton.SED;
        _monedas.text = "Dinero = " + SingletonManager.singleton.Contador;
    }

    //vamos actualizando las variables a la vez que tambien la interfaz del juego
    private void Update()
    {
        //Actualizamos los textos
        _monedas.text = "Dinero = " + SingletonManager.singleton.Contador;
        scoreText.text = "Score = " + SingletonManager.singleton.scoreGlobal;
        _textcomida.text = "hambre" + comida;
        _textbebida.text = "sed" + bebida;

        // Vamos disminuyendo la comida y bebida con Time.deltatime
        _currentHunger -= _hungerDeplationRate * Time.deltaTime;
        _currentThirst -= _ThirstDeplationRate * Time.deltaTime;

        // Comprobnamos que si el hambre y la sed son 0 la vida vaya decayendo
        if(_currentHunger <= 0 || _currentThirst <= 0)
        {
            OnPlayerDied?.Invoke();
            _currentHunger = 0;
            _currentThirst = 0;

            _currentStamina -= _staminaDeplationRate * Time.deltaTime;

            // Si la vida es 0 el juego se acaba
            if(_currentStamina <= 0)
            {
                //gameOver.gameObject.SetActive(true);
                SceneManager.LoadScene(7);
            }
        }
        else // Si la comida y la bebida no son cero, la stamina se recarga
        {
         _currentStaminaDelayCounter += Time.deltaTime;

        if (_currentStaminaDelayCounter >= _staminaRechargeDelay)
         {
            _currentStaminaDelayCounter = 0f;
            _currentStamina += _staminaRechargeRate * Time.deltaTime;

            if (_currentStamina > _maxStamina) _currentStamina = _maxStamina;

            //Debug.Log(_currentStamina);
         }
        }

        

    }

    // Metodo para rellenar el hambre y la sed cuando comemos o bebemos
    public void ReplenishHungerThirst(float hungerAmount, float thirstAmount)
    {
        _currentHunger += hungerAmount;
        _currentThirst += thirstAmount;

        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;
        if (_currentThirst > _maxThirst) _currentThirst = _maxThirst;
    }

    
}


