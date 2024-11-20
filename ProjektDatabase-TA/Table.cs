using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektDatabase_TA
{
    public class Tables
    {
        List<Atributtes> Atributtess;
        string name, d_name;
        public Tables()
        {
            Atributtess = new List<Atributtes>();
        }
        public Tables(string d_name, string name)
        {
            Atributtess = new List<Atributtes>();
            this.name = name;
            this.d_name = d_name;
        }

        public string Get_NameD
        {
            get { return d_name; }
        }
        public string Get_Name
        {
            get { return name; }
        }

        public void AddAtributtes(Atributtes a)
        {
            Atributtess.Add(a);
        }
        public int AtributtesCount
        {
            get { return Atributtess.Count; }
        }

        public void Remove(int ind)
        {
            Atributtess.RemoveAt(ind);
        }

        public Atributtes Get_Atribut(int atribut)
        {
            return Atributtess.ElementAt(atribut);
        }

        public string[] DataT()
        {
            string[] array = new string[Atributtess.Count];
            int i = 0;
            foreach (Atributtes a in Atributtess)
            {
                array[i] = a.get_DataType;
                i++;
            }
            return array;
        }
        public string[] Names()
        {
            string[] array = new string[Atributtess.Count];
            int i = 0;
            foreach (Atributtes a in Atributtess)
            {
                array[i] = a.Get_Name;
                i++;
            }
            return array;
        }
        public string[] NamesD()
        {
            string[] array = new string[Atributtess.Count];
            int i = 0;
            foreach (Atributtes a in Atributtess)
            {
                array[i] = a.Get_NameD;
                i++;
            }
            return array;
        }
    }
}
