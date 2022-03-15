using business.Back;
using business.business;
using business.contrato;
using business.div;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace business.implementacao
{
    [Table("MudancaEstado")]
    public class MudancaEstado : BaseModel, IMudancaEstado
    {
        public string velhoEstado { get; set; }
        public string novoEstado { get; set; }
        public DateTime Data { get; set; }
        public int Codigo { get; set; }

        public MudancaEstado() : base()
        {
            this.Data = DateTime.Now;
        }

        public BaseModel MudarEstado(BaseModel VelhoEstado, BaseModel m)
        {
            string estado = "";
            
            estado = VelhoEstado.GetType().Name;  

            var propsList = m.GetType().GetProperties().Where(pro => pro.PropertyType.Name == "List`1").ToList();

            foreach (var item in propsList)
                item.SetValue(m, item.GetValue(VelhoEstado));

            m.Id = 0;

            return m;
        }

        
    }
}
