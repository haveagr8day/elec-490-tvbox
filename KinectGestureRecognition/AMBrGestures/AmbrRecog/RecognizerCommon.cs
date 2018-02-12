﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBrGestures
{ 
    public enum GestureType : byte
    {
        Pause,
        PlaySelect,
        Rewind,
        Forward,
        Menu,
        None,
    };

    public enum RecognizeItemType
    {
        Video,
        Music,
        Photo
    };


    //This is *mostly* a mirror of the speech grammar XML file
    public enum GestureAction : byte
    {
        //MIRROR THE XML FROM HERE TO THE NEXT COMMENT
        ACTIVATION_PHRASE,
        DEACTIVATION_PHRASE,
        SCREEN_OFF,
        SCREEN_PHOTOS,
        SCREEN_VIDEOS,
        SCREEN_MUSIC,
        INPUT_BACK,
        INPUT_UP,
        INPUT_DOWN,
        INPUT_PREVIOUS,
        INPUT_NEXT,
        INPUT_SELECT,
        INPUT_HOME,
        INPUT_CONTEXTMENU,
        INPUT_SCROLLDONE,
        PLAY_MOVIE,
        PLAY_MUSIC,
        PLAYER_PLAY,
        PLAYER_STOP,
        PLAYER_PAUSE,
        PLAYER_FORWARD,
        PLAYER_REWIND,
        PLAYER_SEEKDONE,
        PLAYER_INFO,
        VOLUME_UP,
        VOLUME_DOWN,
        VOLUME_DONE,
        //END MIRROR

        //These are special "gestures" to perform certain actions. They need extra data generated by some sort of function to work.
        PLAYER_OPEN,
        PLAYER_OPEN_ERROR
    }

    public enum KinectActionRecognizedSource
    {
        Speech,
        Gesture,
        Other
    }

    public delegate void KinectActionEventHandler(object sender, KinectRecognizedActionEventArgs e);

    public interface IKinectActionRecognizer
    {
        event KinectActionEventHandler KinectActionRecognized;
    }

    public class KinectRecognizedActionEventArgs : EventArgs
    {
        private KinectActionRecognizedSource _actionSource;
        private GestureAction _actionType;
        private string _actionData;

        public KinectRecognizedActionEventArgs(KinectActionRecognizedSource source, GestureAction type)
        {
            _actionSource = source;
            _actionType = type;
            _actionData = null;
        }

        public KinectRecognizedActionEventArgs(KinectActionRecognizedSource source, GestureAction type, string data)
        {
            _actionSource = source;
            _actionType = type;
            _actionData = data;
        }

        public KinectActionRecognizedSource ActionSource { get { return _actionSource; } }
        public GestureAction ActionType { get { return _actionType; } }

        public string ActionData { get { return _actionData; } }
    }

    class RecognizerCommon
    {
    }
}
