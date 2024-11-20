using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektDatabase_TA
{
    public class Atributtes
    {
        string DataType, NameD, Name;
        int Max, Min;

        int MaxLength, MinLength;
        bool FirstCap;

        Tables TablesID;

        public Atributtes(string DataType, string NameD, string Name, int MaxLength, int MinLength, bool FirstCap)
        {
            this.DataType = DataType;
            this.NameD = NameD;
            this.Name = Name;
            this.MaxLength = MaxLength;
            this.MinLength = MinLength;
            this.FirstCap = FirstCap;
        }
        public Atributtes(string DataType, string NameD, string Name, int Max, int Min)
        {
            this.DataType = DataType;
            this.NameD = NameD;
            this.Name = Name;
            this.Max = Max;
            this.Min = Min;
        }
        public Atributtes(string DataType, string NameD, string Name)
        {
            this.DataType = DataType;
            this.NameD = NameD;
            this.Name = Name;
        }
        public Atributtes(string DataType, string NameD, string Name, Tables TablesID)
        {
            this.DataType = DataType;
            this.NameD = NameD;
            this.Name = Name;
            this.TablesID = TablesID;
        }
        public Atributtes()
        {
            DataType = "";
        }

        public string get_DataType
        {
            get { return DataType; }
        }
        public string Get_NameD
        {
            get { return NameD; }
        }
        public string Get_Name
        {
            get { return Name; }
        }

        public Tables get_Tables
        {
            get { return TablesID; }
        }

        public string set(string text)
        {
            switch (DataType)
            {
                case "number":
                case "date":
                case "double":
                case "id":
                case "text":
                case "VARCHAR":
                case "bit":
                    return "";
                default:
                    return " - Dataype doesn't exist";
            }
        }

    }
}