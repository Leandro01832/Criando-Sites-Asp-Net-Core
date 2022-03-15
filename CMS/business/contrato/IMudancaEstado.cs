using business.business;

namespace business.contrato
{
    interface IMudancaEstado
    {
        BaseModel MudarEstado(BaseModel velho, BaseModel m);
    }
}
