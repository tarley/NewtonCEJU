using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Newton.CJU.Models
{
    public class Pergunta
    {
        public int ID { get; set; }
        public int AreaJuridicaID { get; set; }
        public string Descricao { get; set; }

        public virtual AreaJuridica AreaJuridica { get; set; }
    }
}