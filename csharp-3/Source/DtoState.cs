using System;
using System.Collections.Generic;
using System.Text;

namespace Codenation.Challenge
{
    public class DtoState
    {
        public string StateAcronym { get; set; }
        public string StateName { get; set; }
        public long StateArea { get; set; }

        public DtoState(string stateAcronym, string stateName, long stateArea)
        {
            StateAcronym = stateAcronym;
            StateName = stateName;
            StateArea = stateArea;
        }
    }
}
