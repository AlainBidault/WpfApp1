using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MemoryWPF.Vue
{
    public abstract class VueModele : INotifyPropertyChanged
    {
        public abstract event PropertyChangedEventHandler PropertyChanged;
    }
}
