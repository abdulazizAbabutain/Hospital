using Application.Common.Model;
using Application.Queries.CommonModle;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Departments.AddDepartment
{
    /// <summary>
    /// يحتوي على الإسم و الوصف باللغتين لإنشاء قسم 
    /// </summary>
    public class AddDepartmentCommand : IRequest<QueryModel>
    {
        public EntityNameDto Name { get; set; }
    }
}
