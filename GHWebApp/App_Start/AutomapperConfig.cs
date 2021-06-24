
using System;
using AutoMapper;
using GHWebApp.Models;

namespace GHWebApp
{
    public class AutomapperConfig
    {
        public static void RegisterMappings()
        {
	    
           

            //cargos
            Mapper.CreateMap<EmployeeViewModel, temployees>();
            Mapper.CreateMap<temployees, EmployeeViewModel>();






            //Prueba transacciones a transaccionRegistroViewModel
            Mapper.CreateMap<temployees, EmployeeViewModel>()
                .ForMember(t => t.FName, m => m.MapFrom(tr => tr.FName))
                .ForMember(t => t.IDDept, m => m.MapFrom(tr => tr.IDDept))
                .ForMember(t => t.IDEmployees, m => m.MapFrom(tr => tr.IDEmployees))
                .ForMember(t => t.IDExp, m => m.MapFrom(tr => tr.IDExp))
                .ForMember(t => t.IDJobs, m => m.MapFrom(tr => tr.IDJobs))
                .ForMember(t => t.IDLangs, m => m.MapFrom(tr => tr.IDLangs))
                .ForMember(t => t.IDSkills, m => m.MapFrom(tr => tr.IDSkills))
                .ForMember(t => t.IDTraining, m => m.MapFrom(tr => tr.IDTraining))
                .ForMember(t => t.IDType, m => m.MapFrom(tr => tr.IDType))
                .ForMember(t => t.LName, m => m.MapFrom(tr => tr.LName))

                .ForMember(t => t.RealID, m => m.MapFrom(tr => tr.RealID))
                .ForMember(t => t.Recommended, m => m.MapFrom(tr => tr.Recommended))
                .ForMember(t => t.Salary, m => m.MapFrom(tr => tr.Salary))
                .ForMember(t => t.Status, m => m.MapFrom(tr => tr.Status))
                .ForMember(t => t.tdepts, m => m.MapFrom(tr => tr.tdepts))
                .ForMember(t => t.texps, m => m.MapFrom(tr => tr.texps))

                .ForMember(t => t.tjobs, m => m.MapFrom(tr => tr.tjobs));





        }






    }
}