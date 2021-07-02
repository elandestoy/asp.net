using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GHWebApp.DataServices
{
    public class EmployeeServices
    {
        private Model1 db = new Model1();


        


        //public PagedResult<temployees> ObtenerUltimasTransacciones(
        //                                                             string sortColumn,
        //                                                             string sortDirection, int iDisplayStart, int iDisplayLength,
        //                                                             int registro,
        //                                                             string usuario,
        //                                                             string nombre,
        //                                                             int transaccionId, int tipo = -1)
        //{
        //    return CrearQueryObtenerTransacciones(sortColumn, sortDirection, iDisplayStart, iDisplayLength, registro, usuario, nombre, transaccionId, tipo);
        //}


        //private PagedResult<temployees> CrearQueryObtenerTransacciones(string sortColumn, string sortDirection, int iDisplayStart, int iDisplayLength, int registro, string usuario,
        //                                            string nombre, int transaccionId, int usuarioId = 0, bool excluirUsuario = false)
        //{
        //    var pred = PredicateBuilder.True<temployees>();
        //    var date = DateTime.Now.AddDays(-2);
        //    pred = pred.And(p => p.ApprovedDate >= date);
        //    //pred = (estadoId > 0) ? pred.And(p => p.Estatus == estadoId) : pred;

        //    //if (!excluirUsuario)
        //    //    pred = (usuarioId > 0) ? pred.And(p => p.UsuarioAsignadoId == usuarioId) : pred;

        //    pred = (transaccionId > 0) ? pred.And(p => p.IDEmployees == transaccionId) : pred;
        //    pred = (registro > 0) ? pred.And(p => p.RealID == registro) : pred;
        //    //pred = (numeroTransaccionOficinaVirtual > 0) ? pred.And(p => p.TransaccionIdAnterior == numeroTransaccionOficinaVirtual) : pred;
        //    pred = (usuario.Length > 0) ? pred.And(p => p.FName == usuario) : pred;
        //    pred = (nombre.Length > 0) ? pred.And(p => p.LName.ToLower().Contains(nombre.ToLower())) : pred;
        //    //pred = (contacto.Length > 0) ? pred.And(p => p.NombreContacto.ToLower().Contains(contacto.ToLower())) : pred;
        //    var totalRecords = GetCount();
        //   // var result = _repository.SelectAll(pred, sortColumn, iDisplayLength, iDisplayStart, sortDirection.ToLower().Equals("desc"));
        //    return new PagedResult<temployees>(result, totalRecords);
        //}


        //private int GetCount()
        //{
        //    int resp = 0;

        //    resp  = db.temployees.Where(a => a.Status ==true).Count();

        //  //  if(resp > 0)


        //    return resp;
        //}
    }
}