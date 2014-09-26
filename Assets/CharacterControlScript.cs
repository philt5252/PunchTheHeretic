using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets
{
    public class CharacterControlScript : MonoBehaviour
    {
        public int Points;

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
            stopwatch.Stop();

            Animator animator = this.GetComponent<Animator>();
            animator.Play("HereticPunched");

        }

        public void DestroyHeretic()
        {
            Destroy(this.gameObject);
        }

    }
}