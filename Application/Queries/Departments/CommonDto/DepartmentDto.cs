using Application.Common.Mapping;
using Application.Common.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.Departments.CommonDto
{
    /// <summary>
    /// يحتوي على رقم المعرف للقسم و الإسم و الوصف للغتين العربية و الإنجليزية
    /// </summary>
    public class DepartmentDto : IMapForm<Department>
    {
        /// <summary xml:lan="Ar">
        /// رقم المعرف بالقسم
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// عرض الإسم والوصف
        /// </summary>
        public EntityNameDto Name { get; set; }
        /// <summary>
        /// عرض حالة القسم 
        /// </summary>
        public LookupDto Status { get; set; }  
    }
}
