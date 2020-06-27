﻿using SelfDef.Variables;
using UnityEngine;

namespace SelfDef.Systems.Loading
{
    public class Initializer : MonoBehaviour
    {
#pragma warning disable CS0649
        public static Initializer Instance { get; private  set; }
        
        [SerializeField] 
        private Texture2D cursorTexture;
        
        public PersistentVariables persistentVariable;
        public PlayerVariables playerVariables;

        private const CursorMode CursorMode = UnityEngine.CursorMode.Auto;
        private readonly Vector2 _hotSpot = Vector2.zero;

#pragma warning restore CS0649
        private void Awake()
        {
            if (Instance == null) { Instance = this; } else { Destroy(gameObject); }

            InitializePersistentVariable();
            
            InitializePlayerVariable();

            DontDestroyOnLoad(this.gameObject);
            
            Cursor.SetCursor(cursorTexture, _hotSpot, CursorMode);
        }

        private void InitializePlayerVariable()
        {
            playerVariables.currentLife = 0;
            playerVariables.currentStamina = 0;
            playerVariables.money = 0;

            playerVariables.ultimate = false;
            playerVariables.explodeOnImpact = false;
        }

        private void InitializePersistentVariable()
        {
            persistentVariable.currentLevelIndex = 0;
            persistentVariable.activeEnemies = 0;
            persistentVariable.enemySpawnFinished = 0;
            persistentVariable.loading = false;
        }

        private void OnMouseEnter()
        {
            Cursor.SetCursor(cursorTexture, _hotSpot, CursorMode);
        }

        private void OnMouseExit()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode);
        }
    }
}
