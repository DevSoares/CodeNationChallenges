using System;

namespace Codenation.Challenge
{
    public class Country
    {        
        public State[] Top10StatesByArea()
        {
            State[] brazilianStates = new State[10];

            brazilianStates[0] = new State("Amazonas", "AM");
            brazilianStates[1] = new State("Pará", "PA");
            brazilianStates[2] = new State("Mato Grosso", "MT");
            brazilianStates[3] = new State("Minas Gerais", "MG");
            brazilianStates[4] = new State("Bahia", "BA");
            brazilianStates[5] = new State("Mato Grosso do Sul", "MS");
            brazilianStates[6] = new State("Goiás ", "GO");
            brazilianStates[7] = new State("Maranhão ", "MA");
            brazilianStates[8] = new State("Rio Grande do Sul", "RS");
            brazilianStates[9] = new State("Tocantins", "TO");

            return brazilianStates;
        }
    }
}
