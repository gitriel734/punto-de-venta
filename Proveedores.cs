using Dapper;
using PV.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta.BML
{
    class Proveedores
    {
        private DataAccess dataaccess = DataAccess.Instance();
        public int idProveedor { get; set; }

        public string nombre { get; set; }

        public string telefono { get; set; }

        public Proveedores()
        {
        }

        public int add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@nombre", nombre);
            parametros.Add("@telefono", telefono);
            return dataaccess.Execute("stp_proveedor_add", parametros);
        }

        public int delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProveedor", idProveedor);
            return dataaccess.Execute("stp_proveedor_delete", parametros);
        }

        public List<Productos> GetAll()
        {

            return dataaccess.Query<Productos>("stp_proveedor_getall");
        }

        public Productos GetById()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProveedor", idProveedor);
            return dataaccess.QuerySingle<Productos>("stp_proveedor_getbyid", parametros);
        }

        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProveedor", idProveedor);
            parametros.Add("@nombre", nombre);
            parametros.Add("@telefono", telefono);
            return dataaccess.Execute("stp_proveedor_add", parametros);


        }
    }

}
