using System;
using System.Collections.Generic;
using Labb2OOADSimonOTobias.Objects;

namespace Labb2OOADSimonOTobias
{
    public interface ICallback
    {
        void Callback(int pwned, List<BreachedSites> result);
    }
}
