using Dapper;
using PV.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Punto_Venta.BML
{
    public class Productos
    {
        private DataAccess dataaccess = DataAccess.Instance();

        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public string unidadMedida { get; set; }
        public String codigo { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string marca { get; set; }
        public bool activo { get; set; }

        public Productos()
        {
        }

        public int add()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@descripcion", descripcion);
            parametros.Add("@unidadMedida", unidadMedida);
            parametros.Add("@codigo", codigo);
            parametros.Add("@precio", precio);
            parametros.Add("@stock", stock);
            parametros.Add("@marca", marca);
            parametros.Add("@activo", activo);
            return dataaccess.Execute("stp_producto_add", parametros);
        }
        public int delete()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            return dataaccess.Execute("stp_Productos_delete", parametros);
        }
        public List<Productos> GetAll()
        {
           
            return dataaccess.Query<Productos>("stp_Productos_getall");
        }
        public Productos GetById()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            return dataaccess.QuerySingle<Productos>("stp_Productos_getbyid", parametros);
        }
        public int Update()
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idProducto", idProducto);
            parametros.Add("@descripcion", descripcion);
            parametros.Add("@unidadMedida", unidadMedida);
            parametros.Add("@codigo", codigo);
            parametros.Add("@precio", precio);
            parametros.Add("@stock", stock);
            parametros.Add("@marca", marca);
            parametros.Add("@activo", activo);
            return dataaccess.Execute("stp_Productos_add", parametros);
        }
    }
}
