using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MusicManagement
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] List<MusicClipGroup> _musicClipGroups;
        [SerializeField] List<MusicMix> _musicMixes;

        int _currentMixIndex = 0;
        MusicClipGroup _currentMusicGroup;

        [ContextMenu("Peaceful Music")]
        public void PlayPeacefulMusic()
        {
            PlayMusic("Peaceful");
        }

        [ContextMenu("Anxious Music")]
        public void PlayAnxiousMusic()
        {
            PlayMusic("Anxious");
        }

        [ContextMenu("NightMusic")]
        public void PlayNightMusic()
        {
            PlayMusic("Night");
        }

        void Start()
        {
            InitializeMusicClipGroups();
            InitializeMusicMixes();
            PlayMusic("Peaceful");
        }

        private void InitializeMusicMixes()
        {
            foreach (var mix in _musicMixes)
            {
                mix.Initialize(this);
            }
        }

        void InitializeMusicClipGroups()
        {
            foreach (var musicGroup in _musicClipGroups)
            {
                musicGroup.Initialize(this);
            }
        }

        void PlayMusic(string musicGroupName)
        {
            StopAllCoroutines();
            _currentMusicGroup = GetMusicGroup(musicGroupName);
            PlayNextTrack();
        }

        MusicClipGroup GetMusicGroup(string musicGroupName)
        {
            return _musicClipGroups.FirstOrDefault(group => group.name == musicGroupName);
        }

        void PlayNextTrack()
        {
            var clip = _currentMusicGroup.GetNextMusicClip();
            ToggleCurrentMix();
            _musicMixes[_currentMixIndex].PlayClip(clip);
            StartCoroutine(QueueNextTrack(clip.length));
        }

        IEnumerator QueueNextTrack(float delay)
        {
            yield return new WaitForSeconds(delay);
            PlayNextTrack();
        }

        public void ToggleCurrentMix()
        {
            _currentMixIndex = _currentMixIndex == 0 ? 1 : 0;
        }



    }
}