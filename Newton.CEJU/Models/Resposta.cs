using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Resposta
    {
        public int ID { get; set; }
        public int PerguntaID { get; set; }
        public string Descricao { get; set; }

        public virtual Pergunta Pergunta { get; set; }

    }
}