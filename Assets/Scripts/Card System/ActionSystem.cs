// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class ActionSystem : Singleton<ActionSystem>
// {
//     private List<GameAction> reactions = null;
//     public bool IsPerforming { get; private set; } = false;

//     // Reactions that happen before action
//     private static Dictionary<Type, List<Action<GameAction>>> preSubs = new();
//     // Reactions that happen after action
//     private static Dictionary<Type, List<Action<GameAction>>> postSubs = new();
//     private static Dictionary<Type, Func<GameAction, IEnumerator>> performers = new();
    
//     public static void AttachPerformer<T>(Func<T, IEnumerator> performer) where T : GameAction
//     {
//         Type type = typeof(T);
//         IEnumerator wrappedPerformer(GameAction action) => performer((T)action);
//         if (performers.ContainsKey(type)) performers[type] = wrappedPerformer;
//         else performers.Add(type, wrappedPerformer);
//     }

//     public static void DetachPerformer<T>() where T : GameAction
//     {
//         Type type = typeof(T);
//         if(performers.ContainsKey(type)) performers.Remove(type);
//     }

//     public static void SubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
//     {

//     }

//     public static void UnsubscribeReaction<T>(Action<T> reaction, ReactionTiming timing) where T : GameAction
//     {

//     }
// }
