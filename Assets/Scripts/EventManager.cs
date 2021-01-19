//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//public class EventManager : MonoBehaviour
//{
//    #region Singelton
//    public static EventManager Instance
//    {
//        get
//        {
//            return instance;
//        }
//    }
   
//      private static EventManager instance;

//    private void Awake()
//    {
//        if(instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            DestroyImmediate(this);
//        }
//        SceneManager.sceneLoaded += LoadScene;
//    }

//    #endregion

//    void LoadScene(Scene scene, LoadSceneMode mode)
//    {
//        RemoveRedundancies();
//    }

//    private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new Dictionary<EVENT_TYPE, List<IListener>>();

//    public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
//    {
//        List<IListener> ListenList = null;

//        if(Listeners.TryGetValue(Event_Type, out ListenList)){
//            ListenList.Add(Listener);
//            return;
//        }
//        ListenList = new List<IListener>();
//        ListenList.Add(Listener);
//        Listeners.Add(Event_Type, ListenList);
//    }
         
//    public void PostNotifications(EVENT_TYPE Event_Type)
//    {
//        List<IListener> ListenList = null;
//        if (!Listeners.TryGetValue(Event_Type, out ListenList))
//            return;

//        for(int i = 0; i<ListenList.Count; i++)
//        {
//            if (!ListenList[i].Equals(null))
//                ListenList[i].OnEvent(Event_Type);
//        }
//    }

//    public void RevoveEvent(EVENT_TYPE Event_Type)
//    {
//        Listeners.Remove(Event_Type);
//        RemoveRedundancies();

//    }

//    public void RemoveRedundancies()
//    {
//        Dictionary<EVENT_TYPE, List<IListener>> TmpListeners = new Dictionary<EVENT_TYPE, List<IListener>>();

//        foreach(KeyValuePair<EVENT_TYPE, List<IListener>> Item in Listeners)
//        {
//            for(int i = Item.Value.Count-1; i>=0; i--)
//            {
//                if (Item.Value[i].Equals(null))
//                    Item.Value.RemoveAt(i);
//            }
//            if (Item.Value.Count > 0)
//                TmpListeners.Add(Item.Key, Item.Value);
//        }
//        Listeners = TmpListeners;
//    }

//    //private void OnLevelWasLoaded(int level)
//    //{
//    //    {
//    //    }
//    //}

//    private void Start()
//    {
        
//    }

//}
