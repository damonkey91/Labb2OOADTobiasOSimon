using System;
using System.Collections.Generic;
using Labb2OOADSimonOTobias.Objects;

namespace Labb2OOADSimonOTobias.ViewModels
{
    public class ListViewViewModel : BaseViewModel
    {
        public List<BreachedSites> ListSource {get; set;}

        public ListViewViewModel(List<BreachedSites> result)
        {
            ListSource = result;
        }
    }
}
