using System;
using System.Collections.Generic;
using UnityEngine;

namespace MusicManagement
{
    [CreateAssetMenu(fileName = "MusicClipGroup", menuName = "Music Clip Group", order = 3)]

    public class MusicClipGroup: ScriptableObject
    {
        [SerializeField] List<AudioClip> _musicList;

        Queue<AudioClip> _trackQueue;
        List<AudioClip> _tempList;

        public void Initialize(MusicManager musicManager)
        {
            InitializeTrackQueues();
        }

        public AudioClip GetNextMusicClip()
        {
            if (_trackQueue.Count == 0) ShuffleTrackQueue();
            var clip = _trackQueue.Dequeue();
            return clip;
        }

        void ShuffleTrackQueue()
        {
            if (_trackQueue.Count != 0) return;
            _tempList.Clear();
            foreach (var track in _musicList)
            {
                _tempList.Add(track);
            }

            while (_tempList.Count > 0)
            {
                var randomIndex = UnityEngine.Random.Range(0, _tempList.Count);
                _trackQueue.Enqueue(_tempList[randomIndex]);
                _tempList.RemoveAt(randomIndex);
            }
        }

        void InitializeTrackQueues()
        {
            _trackQueue = new Queue<AudioClip>();
            _tempList = new List<AudioClip>();
        }
    }
}