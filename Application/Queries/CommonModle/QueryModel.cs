using Application.Common.Mapping;
using Application.Common.Model;
using AutoMapper;
using Domain.Entities;

namespace Application.Queries.CommonModle
{
    /// <summary>
    /// يحتوي على رقم المعرف للكيان و الإسم و الوصف للغتين العربية و الإنجليزية
    /// </summary>
    public class QueryModel : IMapForm<Department>, 
        IMapForm<EmployeePosition>
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
