/*
Copyright (c) 2023 Xavier Arpa López Thomas Peter ('xavierarpa')

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
using UnityEngine;

namespace UniFlux.Toolkit.Sample
{
    public sealed class Sample_1 : MonoFlux
    {
        private const string KEY = "__uniflux_sample_key";
        [SerializeField] private KeyFlux sampleKey;
        
        protected override void OnFlux(in bool condition)
        {
            sampleKey.Store(OnSampleKeyByParameter, condition);
        }

        private void OnSampleKeyByParameter()
        {
            Debug.Log("Key Pressed! (From Parameter)");
        }

        [MethodFlux(KEY)]
        private void OnSampleKey()
        {
            Debug.Log("Key Pressed!");
        }

        [StateFlux(KEY)]
        private void OnSampleKeyInput(string value)
        {
            Debug.Log(value);
        }

        [StateFlux(KEY)]
        private void OnSampleKeySlider(float value)
        {
            Debug.Log(value);
        }

        [StateFlux(KEY)]
        private void OnSampleKeyDropdown(int value)
        {
            Debug.Log(value);
        }

        [StateFlux(KEY)]
        private void OnSampleKeyToggle(bool value)
        {
            Debug.Log(value);
        }

    }
}