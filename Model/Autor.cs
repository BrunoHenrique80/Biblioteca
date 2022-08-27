using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Autor
    {
        //propierts private
        private int codigo;
        private string nomeAutor;

        //propierts public
        public string NOME_AUTOR
        {
            get { return nomeAutor; }
            set { nomeAutor = value; }
        }
        public int CODIGO
        {
            get { return codigo; }
            set { codigo = value; }
        }

    }
}
