using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour {

  // VARIABLES
  private Dictionary <string, UnityEvent> eventDictionary; 
  private static EventManager eventManager;

  // PROPERTIES
  public static EventManager Instance {
    get {
      if (!eventManager) {
        eventManager = FindObjectOfType(typeof(EventManager)) as EventManager;
        if (!eventManager) {
          Debug.LogError("There needs to be one active EventMananger script on a GameObject in your scene.");
        } else {
          if (eventManager.eventDictionary == null) 
            eventManager.eventDictionary = new Dictionary<string, UnityEvent>();
        }
      }
      return eventManager;
    }
  }

  // PUBLIC BEHAVIOUR
  public static void StartListening(string eventName, UnityAction listener) {
    UnityEvent thisEvent = null;
    if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
      thisEvent.AddListener(listener);
    } else {
      thisEvent = new UnityEvent();
      thisEvent.AddListener(listener);
      Instance.eventDictionary.Add(eventName, thisEvent);
    }
  }

  public static void StopListening(string eventName, UnityAction listener) {
    if (eventManager == null)
      return;
    UnityEvent thisEvent = null;
    if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
      thisEvent.RemoveListener(listener);
    }
  }

  public static void TriggerEvent(string eventName) {
    UnityEvent thisEvent = null;
    if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent)) {
      thisEvent.Invoke();
    }
  }

}