using System;
using System.Collections.Generic;
using System.Linq;
using Perb.Framework.Domains.Write.States;

namespace Perb.Framework.Infrastructure.Extensions
{
    public static class ListExtensions
    {
        public static void Merge<TState, TInput>(this IList<TState> currentList, IList<TInput> newList,
            Func<TInput, TState> onAdd,
            Action<TState, TInput> onChange) 
        
            where TState: BaseState
            where TInput: IIdentifiable
        {
            var changed = newList.Where(x => currentList.Select(n => n.Id).Contains(x.Id)).ToList();
            var removed = currentList.Where(x => newList.Select(n => n.Id).Contains(x.Id) == false).ToList();
            var added = newList.Where(x => currentList.Select(n => n.Id).Contains(x.Id) == false).ToList();

            foreach (var c in changed)
            {
                var currentState = currentList.First(x => x.Id == c.Id);
                onChange(currentState, c);
            }

            foreach (var r in removed)
            {
                currentList.Remove(r);
            }

            foreach (var a in added)
            {
                currentList.Add(onAdd(a));
            }
        }
        
        public static void Merge<T>(this IList<T> currentList, IList<T> newList)
        {
            var removed = currentList.Where(x => newList.Contains(x) == false).ToList();
            var added = newList.Where(x => currentList.Contains(x) == false).ToList();

            foreach (var r in removed)
            {
                currentList.Remove(r);
            }

            foreach (var a in added)
            {
                currentList.Add(a);
            }
        }
    }
}