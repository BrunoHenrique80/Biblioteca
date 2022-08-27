using DAL;
using System.Data;

namespace BLL
{
    public class CidadeBLL
    {
        //Método de buscar cadastros de cidades que estão cadastradas e armazenadas no banco de dados.
        public DataTable Buscar(string _filtro)
        {
            CidadeDAL cidadeDAL = new CidadeDAL();
            return cidadeDAL.Buscar(_filtro);
        }
    }
}
