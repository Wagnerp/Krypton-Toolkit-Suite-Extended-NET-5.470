﻿#region License and Copyright
/*
 
Copyright (c) Guifreaks - Jacob Mesu
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:
    * Redistributions of source code must retain the above copyright
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of the Guifreaks nor the
      names of its contributors may be used to endorse or promote products
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL <COPYRIGHT HOLDER> BE LIABLE FOR ANY
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/
#endregion


using ExtendedControls.ExtendedToolkit.NaviSuite.Main.Controls;
using System.Collections.Generic;

namespace ExtendedControls.ExtendedToolkit.NaviSuite.Main.Common
{
    public class NaviBandEnumerator : IEnumerator<NaviBand>
    {
        private int curIndex;
        private NaviBand current;
        private NaviBandCollection collection;

        public NaviBandEnumerator(NaviBandCollection collection)
        {
            this.collection = collection;
            curIndex = -1;
            current = default(NaviBand);
        }

        #region IEnumerator<NaviBand> Members

        public NaviBand Current
        {
            get { return current; }
        }

        #endregion

        #region IDisposable Members

        public void Dispose() { }

        #endregion

        #region IEnumerator Members

        object System.Collections.IEnumerator.Current
        {
            get { return current; }
        }

        public bool MoveNext()
        {
            if (++curIndex >= collection.Count)
                return false;
            else
                current = collection[curIndex];
            return true;
        }

        public void Reset()
        {
            curIndex = -1;
        }

        #endregion
    }
}