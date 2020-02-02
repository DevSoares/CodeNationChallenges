using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class Country
    {
        public List<string> dataStates = new List<string>()
        {
            "AC;Acre;164123040",
            "AL;Alagoas;27778506",
            "AP;Amapá;142 828,521 ",
            "AM;Amazonas;1 559 159,148",
            "BA;Bahia;564 733,177",
            "CE;Ceará;148 920,472 ",
            "DF;Distrito Federal;5 779,999 ",
            "ES;Espírito Santo;46 095,583 ",
            "GO;Goiás; 340 111,783 ",
            "MA;Maranhão;331 937,450",
            "MT;Mato Grosso;903 366,192",
            "MS;Mato Grosso do Sul;357 145,532",
            "MG;Minas Gerais;586 522,122",
            "PA;Pará;1 247 954,666",
            "PB;Paraíba;56 585,000 ",
            "PR;Paraná;199 307,922",
            "PE;Pernambuco;98 311,616 ",
            "PI;Piauí;251 577,738",
            "RJ;Rio de Janeiro;43 780,172",
            "RN;Rio Grande do Norte;52 811,047",
            "RS;Rio Grande do Sul;281 730,223",
            "RO;Rondônia;237 590,547",
            "RR;Roraima;224 300,506",
            "SC;Santa Catarina;95 736,165 ",
            "SP;São Paulo;248 222,362",
            "SE;Sergipe;21 915,116",
            "TO;Tocantins;277 720,520 "
        };

        public State[] Top10StatesByArea()
        {
            var states = GetStates(dataStates);
            states = states.OrderByDescending(s => s.StateArea).Take(10).ToList();

            State[] brazilianStates = new State[10];

            for (int i = 0; i < states.Count; i++)
            {
                brazilianStates[i] = new State(states[i].StateName, states[i].StateAcronym);
            }

            return brazilianStates;
        }

        public List<DtoState> GetStates(List<string> list)
        {
            var dtoStateList = new List<DtoState>();
            string stateName = string.Empty;
            string stateAcronym = string.Empty;
            long stateArea = 0;

            foreach (var data in list)
            {

                var tempState = data.Split(';');
                for (int i = 0; i < tempState.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            stateAcronym = tempState[i];
                            break;

                        case 1:
                            stateName = tempState[i];
                            break;
                        case 2:
                            stateArea = long.Parse(RemoveWhiteSpace(tempState[i].Replace(',', ' ')));
                            break;
                        default:
                            break;
                    }
                }

                dtoStateList.Add(new DtoState(stateAcronym, stateName, stateArea));
            }

            return dtoStateList;
        }

        public string RemoveWhiteSpace(string stringObject)
        {
            string returnString = string.Empty;
            foreach (char ch in stringObject)
            {
                if (!Char.IsWhiteSpace(ch))
                    returnString += ch;
            }

            return returnString;
        }
    }
}
