using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DigitoVerificadorBLL
    {
        public void RecalcularDigitos()
        {
            DAL.DigitoVerificador dv = new DAL.DigitoVerificador();
            dv.RecalcularDigitos();
        }

        public List<String> VerificarDV()
        {
            DAL.DigitoVerificador DigitoV = new DAL.DigitoVerificador();
            BLL.Bitacora bit = new BLL.Bitacora();

            var lista = new List<String>();
            lista = DigitoV.VerificarDV();

            foreach (var registro in lista)
            {
                bit.RegistrarBitacora(registro.ToString(),"ALTA");
            }

            return lista;
        }
    }
}
