//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MaestroDetalleDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public partial class TB_DEMANDA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TB_DEMANDA()
        {
            this.TB_DETALLE_DEMANDA = new HashSet<TB_DETALLE_DEMANDA>();
            
        }
       
        public string NUM_DEMANDA { get; set; }
        public string COD_DANTE { get; set; }
        public string COD_DADO { get; set; }
        public Nullable<System.DateTime> FECHA_DEMANDA { get; set; }
        public string LUG_DEMANDA { get; set; }
        public Nullable<System.DateTime> FECHA_ING { get; set; }
        public Nullable<System.DateTime> FECHA_CESE { get; set; }
        public string MOT_CESE { get; set; }
        public string CARGO { get; set; }
        public string TIPO_REM { get; set; }
        public decimal ULT_REM { get; set; }

        public virtual TB_DEMANDANTE TB_DEMANDANTE { get; set; }
        public virtual TB_DEMANDADO TB_DEMANDADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TB_DETALLE_DEMANDA> TB_DETALLE_DEMANDA { get; set; }

        public List<TB_DEMANDA> Listar(int pageIndex, int pageSize, out int pageCount)
        {
            List<TB_DEMANDA> orders = new List<TB_DEMANDA>();
            using (SqlConnection conexion = new SqlConnection("Data Source=ARANTXA-PC\\SQLEXPRESS;Initial Catalog=PODER_JUDICIAL;Integrated Security=True;"))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("Usp_demanda_Listar", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.CommandTimeout = 0;
                    comando.Parameters.AddWithValue("@pageIndex", pageIndex);
                    comando.Parameters.AddWithValue("@pageSize", pageSize);
                    comando.Parameters.AddWithValue("@pageCount", 0).Direction = ParameterDirection.Output;
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            TB_DEMANDA order = null;
                            while (reader.Read())
                            {
                                order = new TB_DEMANDA();
                                order.NUM_DEMANDA = (String)reader["NUM_DEMANDA"];
                                order.COD_DANTE = (String)reader["COD_DANTE"];
                                order.COD_DADO = (String)reader["COD_DADO"];
                                if (reader["FECHA_DEMANDA"] != DBNull.Value) order.FECHA_DEMANDA = (DateTime)reader["FECHA_DEMANDA"];
                                order.LUG_DEMANDA = (String)reader["LUG_DEMANDA"];
                                if (reader["FECHA_ING"] != DBNull.Value) order.FECHA_ING = (DateTime)reader["FECHA_ING"];
                                if (reader["FECHA_CESE"] != DBNull.Value) order.FECHA_CESE = (DateTime)reader["FECHA_CESE"];
                                order.MOT_CESE = (String)reader["MOT_CESE"];
                                order.CARGO = (String)reader["CARGO"];
                                order.TIPO_REM = (String)reader["TIPO_REM"];
                                order.ULT_REM = (Decimal)reader["ULT_REM"];
                                orders.Add(order);
                            }
                        }
                    }

                    pageCount = (int)comando.Parameters["@pageCount"].Value;
                }
            }
            return orders;
        }
        public String generarCodigo()
        {
            String codigo = "";
            using (SqlConnection conexion = new SqlConnection("Data Source=ARANTXA-PC\\SQLEXPRESS;Initial Catalog=PODER_JUDICIAL;Integrated Security=True;"))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("cagDemanda", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    codigo = comando.ExecuteScalar().ToString();
                }


                return codigo;
            }

        }

        public String generarCodigoDetalle()
        {
            String codigo = "";
            using (SqlConnection conexion = new SqlConnection("Data Source=ARANTXA-PC\\SQLEXPRESS;Initial Catalog=PODER_JUDICIAL;Integrated Security=True;"))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand("cagDemandaDetalle", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    codigo = comando.ExecuteScalar().ToString();
                }


                return codigo;
            }

        }
    }
}