using Dapper;
using PV.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta.BML
{
    class Clientes
    {
        private DataAccess dataaccess = DataAccess.Instance();

        public int idCliente { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public string telefono { get; set; }
        public decimal descuento { get; set; }
        public Clientes()
        {
        }

        public int add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            parametros.Add("razonSocial", razonSocial);
            parametros.Add("@telefono", telefono);
            parametros.Add("@descuento", descuento);
            return dataaccess.Execute("stp_Cliente_add", parametros);
        }

        public int delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idCliente", idCliente);
            return dataaccess.Execute("stp_Cliente_delete", parametros);
        }

        public List<Productos> GetAll()
        {

            return dataaccess.Query<Productos>("stp_clientes_getall");
        }

        public Productos GetById()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idCliente", idCliente);
            return dataaccess.QuerySingle<Productos>("stp_clientes_getbyid", parametros);
        }

        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idCliente", idCliente);
            parametros.Add("@nombre", nombre);
            parametros.Add("razonSocial", razonSocial);
            parametros.Add("@telefono", telefono);
            parametros.Add("@descuento", descuento);
            return dataaccess.Execute("stp_Cliente_add", parametros);

        }

    }
}
