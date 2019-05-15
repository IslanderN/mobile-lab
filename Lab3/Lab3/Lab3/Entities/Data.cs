using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab3.Entities
{
    class Data
    {
        public ObservableCollection<string> Faculties { get; set; }

        public ObservableCollection<string> Coureses { get; set; }

        public Data()
        {
            Faculties = new ObservableCollection<string>()
            {
                "ФІОТ",
                "ІПСА",
                "ФПМ"
            };

            Coureses = new ObservableCollection<string>();
            for(int i = 1; i <= 6; i++)
            {
                Coureses.Add(i.ToString());
            }
        }
    }
}
