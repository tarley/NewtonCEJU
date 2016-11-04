using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models.Enum
{

    public enum SituacaoEnum
    {
        [Description("Criado")]
        Criado = 1,
        [Description("Em Analise")]
        EmAnalise = 2,
        [Description("Aguardando Aceite")]
        AguardandoAceite = 3,
        [Description("Respondido")]
        Respondido = 4
    }


}