using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// ReSharper disable InconsistentNaming
// Esta clase tiene taxonomia inconsistente. Pero es adrede porque es requerido por un plugin de javascript
namespace GHWebApp.Models
{
    /// <summary>
    /// Modelo para retornar resultsets de DataTables.JS
    /// </summary>
    public class DataTablesJsViewModel
    {
        public void SetValues(System.Collections.Specialized.NameValueCollection requestKeys)
        {
            mDataProp = requestKeys.AllKeys.Where(p => p.StartsWith("mDataProp")).Select(p => requestKeys[p]).ToArray();
            bSortable = requestKeys.AllKeys.Where(p =>
                p.StartsWith("bSortable"))
                .Where(p => requestKeys[p].Equals("true"))
                .Select(p => mDataProp[int.Parse(p.Split('_')[1])])
                .ToArray();
            bSearchable = requestKeys.AllKeys.Where(p =>
                p.StartsWith("bSearchable"))
                .Where(p => requestKeys[p].Equals("true"))
                .Select(p => mDataProp[int.Parse(p.Split('_')[1])])
                .ToArray();
        }

        /// <summary>
        /// Total de Columnas Desplegadas
        /// </summary>
        public string iColumns { get; set; }
        /// <summary>
        /// Inicio de la paginación
        /// </summary>
        public string iDisplayStart { get; set; }
        /// <summary>
        /// Total de registros a mostrar (paginación)
        /// </summary>
        public string iDisplayLength { get; set; }
        /// <summary>
        /// Search General (para realizar búsqueda por todas las columnas)
        /// </summary>
        public string sSearch { get; set; }
        /// <summary>
        /// Direccion de ordenamiento
        /// </summary>
        public string sSortDir { get; set; }
        /// <summary>
        /// Total de columnas ordenables
        /// </summary>
        public string iSortingCols { get; set; }
        /// <summary>
        /// Nombre de la columna por la que se esta ordenando
        /// </summary>
        public string sortColumnName { get; set; }
        /// <summary>
        /// Regular Expression de las columnas
        /// </summary>
        public string[] bRegex { get; set; }
        /// <summary>
        /// Columnas por las que se puede realizar una busqueda
        /// </summary>
        public string[] bSearchable { get; set; }
        /// <summary>
        /// Columnas por las que se puede ordenar
        /// </summary>
        public string[] bSortable { get; set; }
        /// <summary>
        /// Nombres de las columnas
        /// </summary>
        public string[] mDataProp { get; set; }


        /// <summary>
        /// Total records, before filtering (i.e. the total number of records in the database)
        /// </summary>
        public int iTotalRecords { get; set; }

        /// <summary>
        /// Total records, after filtering (i.e. the total number of records after filtering has been applied - not just the number of records being returned in this result set)
        /// </summary>
        public int iTotalDisplayRecords { get; set; }

        /// <summary>
        /// An unaltered copy of sEcho sent from the client side. This parameter will change with each draw (it is basically a draw count) - so it is important that this is implemented. Note that it strongly recommended for security reasons that you 'cast' this parameter to an integer in order to prevent Cross Site Scripting (XSS) attacks.
        /// </summary>
        public string sEcho { get; set; }

        /// <summary>
        /// Optional - this is a string of column names, comma separated (used in combination with sName) which will allow DataTables to reorder data on the client-side if required for display. Note that the number of column names returned must exactly match the number of columns in the table. For a more flexible JSON format, please consider using mDataProp.
        /// </summary>
        public string sColumns { get; set; }

        /// <summary>
        /// The data in a 2D array. Note that you can change the name of this parameter with sAjaxDataProp.
        /// </summary>
        public dynamic aaData { get; set; }
        public string NombreSociedad { get; set; }
        public int? CantidadAccionistas { get; set; }
        public int? TotalAcciones { get; set; }
        public bool? VisibleEnCertificado { get; set; }
    }
}
// ReSharper restore InconsistentNaming