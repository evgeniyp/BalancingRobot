using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMasterScript : MonoBehaviour
{
    [System.Serializable]
    public class GameObjects
    {
        public GameObject Wheel;
        public GameObject Stick;
    }

    [SerializeField]
    private GameObjects _gameObjects;

    private void Start()
    {

    }

    private void Update()
    {

    }
}
