﻿using System;
using System.Diagnostics;
using UnityEngine;

namespace Assets
{
    public class CharacterControlScript : MonoBehaviour
    {
        public int Points;

        public event EventHandler CharacterPunched;

        public float Lifetime = 6f;

        private Stopwatch stopwatch = new Stopwatch();
        // Use this for initialization
        void Start()
        {
            stopwatch.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (stopwatch.ElapsedMilliseconds > Lifetime * 1000)
            {
                Destroy(this.gameObject);
            }
        }

        void OnMouseDown()
        {
            OnCharacterPunched();
            Destroy(this.gameObject);
        }

        void OnCharacterPunched()
        {
            if (CharacterPunched != null)
                CharacterPunched(this, null);
        }
    }
}