﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GHWebApp.Models
{

    public class EmployeeViewModel
    {
        [Key]
        public int IDEmployees { get; set; }

        [DisplayName("Identification Card Number")]
        [Column(TypeName = "numeric")]
        public decimal RealID { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(20, ErrorMessage = "Training Name must be between 3 to 20", MinimumLength = 3)]
        public string FName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(20, ErrorMessage = "Last Name must be between 3 to 20", MinimumLength = 3)]
        public string LName { get; set; }

        [DisplayName("Position")]
        public int IDJobs { get; set; }

        [DisplayName("Department ")]
        public int IDDept { get; set; }

        [DisplayName("Salary")]
        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        [DisplayName("Skills")]
        public int IDSkills { get; set; }

        [DisplayName("Training")]
        public int IDTraining { get; set; }

        [DisplayName("Experience")]
        public int IDExp { get; set; }

        [DisplayName("Languages")]
        public int IDLangs { get; set; }

        [DisplayName("Recommended by:")]
        [Column(TypeName = "text")]
        public string Recommended { get; set; }

        public int IDType { get; set; }

        public bool Status { get; set; }


        public virtual tdepts tdepts { get; set; }

        public virtual texps texps { get; set; }

        public virtual tjobs tjobs { get; set; }

        public virtual tlangs tlangs { get; set; }

        public virtual tskills tskills { get; set; }

        public virtual ttrainings ttrainings { get; set; }

        public virtual ttype ttype { get; set; }

        ////username:   
        //[DisplayName("User Name")]
        //[StringLength(250)]
        //public string UserName { get; set; }

        

        public static EmployeeViewModel MapearComoViewModel(temployees entidad)
        {
            return Mapper.Map<temployees, EmployeeViewModel>(entidad);
        }
        /// <summary>
        /// Mappea un modelo de datos EmployeeViewModel a una entidad de tipo Employee.
        /// </summary>
        /// <param name="modeloVista">The modelo vista.</param>
        /// <returns></returns>
        public static temployees MapearComoEntidad(EmployeeViewModel modeloVista)
        {
            return Mapper.Map<EmployeeViewModel, temployees>(modeloVista);
        }
    }
}


