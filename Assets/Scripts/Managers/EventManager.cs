using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : Singleton<EventManager> {

  // VARIABLES
  private Dictionary <System.Type, UnityEvent> eventTypeDictionary = new Dictionary<System.Type, UnityEvent>();
  private static EventManager eventManager;
 
  // PUBLIC BEHAVIOUR
  public static void StartListening<T>(UnityAction listener) where T : UnityEvent {
    UnityEvent thisEvent = null;
    if (Instance.eventTypeDictionary.TryGetValue(typeof(T), out thisEvent)) {
      thisEvent.AddListener(listener);
    } else {
      thisEvent = new UnityEvent();
      thisEvent.AddListener(listener);
      Instance.eventTypeDictionary.Add(typeof(T), thisEvent);
    }
  }
 
  public static void StopListening<T>(UnityAction listener) where T : UnityEvent {
    if (instance == null)
      return;
    UnityEvent thisEvent = null;
    if (Instance.eventTypeDictionary.TryGetValue(typeof(T), out thisEvent))
      thisEvent.RemoveListener(listener);
  }

  public static void TriggerEvent(UnityEvent e) {
    UnityEvent thisEvent = null;
    if (Instance.eventTypeDictionary.TryGetValue(e.GetType(), out thisEvent))
      thisEvent.Invoke();
  }

}