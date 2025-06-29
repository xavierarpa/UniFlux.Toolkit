/*
Copyright (c) 2025 Xavier Arpa López Thomas Peter ('xavierarpa')

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using UniFlux.Core;
using UnityEngine;

namespace UniFlux.Toolkit
{
    [CreateAssetMenu(fileName = "KeyFlux", menuName = "UniFlux/KeyFlux", order = -1000)]
    public class KeyFlux : ScriptableObject
    {
        [SerializeField] private bool isCustomKey = false;
        [SerializeField] private string keyName = string.Empty;

        private string Key => isCustomKey ? keyName : name;

        public void Dispatch() => Flux.Dispatch(Key);
        public void Dispatch<T>(T t) => Flux.Dispatch(Key, t);
        public T2 Dispatch<T, T2>() => Flux.Dispatch<string, T2>(Key);
        public T2 Dispatch<T, T2>(T t) => Flux.Dispatch<string, T, T2>(Key, t);
        public void Store(in Action action, bool condition) => Flux.Store(Key, action, condition);
        public void Store<T>(in Action<T> action, bool condition) => Flux.Store(Key, action, condition);
        public void Store<T>(in Func<T> action, bool condition) => Flux.Store(Key, action, condition);
        public void Store<T, T2>(in Func<T, T2> action, bool condition) => Flux.Store(Key, action, condition);
        public void StoreState<T>(in Action<T> callback, in bool condition) => Flux.StoreState(Key, callback, condition);
        public void DispatchState<T>(T @param) => Flux.DispatchState(Key, @param);
        public T GetState<T>() => Flux.GetState(Key, out T @state) ? @state : default;
        public bool GetState<T>(out T @state) => Flux.GetState(Key, out @state);
    }
}

