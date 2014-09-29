using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Assets
{
    public class CharacterControlScript : MonoBehaviour
    {
        public int PointsPunched;
        public int PointsSurvived;

        public event EventHandler CharacterPunched;
        public event EventHandler CharacterSurvived;

        public float Lifetime = 6f;

        private Stopwatch stopwatch = new Stopwatch();
        private bool isActive = true;
        private Animator animator;

        protected virtual string PunchedAnimationName { get { return "Punched"; } }
        protected virtual string SurvivedAnimationName { get { return "Survived"; } }

        // Use this for initialization
        void Start()
        {
            animator = this.GetComponent<Animator>();
            stopwatch.Start();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void FixedUpdate()
        {
            if (isActive && stopwatch.ElapsedMilliseconds > Lifetime * 1000)
            {
                stopwatch.Stop();

                OnCharacterSurvived();

                animator.Play(SurvivedAnimationName);
            }
        }

        void OnMouseDown()
        {
            if (!isActive)
                return;

            stopwatch.Stop();

            OnCharacterPunched();

            animator.Play(PunchedAnimationName);

        }

        public virtual void DestroyCharacter()
        {
            Destroy(gameObject);
        }

        void OnCharacterPunched()
        {
            isActive = false;

            if (CharacterPunched != null)
                CharacterPunched(this, null);
        }

        void OnCharacterSurvived()
        {
            isActive = false;

            if (CharacterSurvived != null)
                CharacterSurvived(this, null);
        }
    }
}