using Application.Commands.Departments.AddDepartment;
using Application.Commands.Departments.DeleteDepartmet;
using Application.Commands.Departments.FullyUpdateDepartment;
using Application.Commands.Departments.UpdateStatusDepartment;
using Application.Common.Model;
using Application.Queries.Departments.CommonDto;
using Application.Queries.Departments.GetDepartment;
using Application.Queries.Departments.GetDepartmentList;
using Application.Queries.Departments.GetDepartmentStatus;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using Web.Common.Extenstions;

namespace Web.Controllers.V1
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator mediator;

        public DepartmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        /// <summary>
        /// اضافة قسم غلى النظام 
        /// </summary>
        /// <remarks>
        /// sample Request
        /// <example>
        /// 
        ///     POST api/Department
        ///
        ///     {
        ///         "nameArabic" : "test"   // required 
        ///         "nameEnglish" : "Internal Medicine Departmnet" // required
        ///         "desceprtionArabic": null, // optoinal
        ///         "desceprtionEnglish": null, // optoinal
        ///     }
        ///    
        /// </example>
        /// </remarks>
        /// 
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddDepartment(AddDepartmentCommand command)
        {
            var deepartment = await mediator.Send(command);
            // will change to redirect method. 
            return CreatedAtAction(nameof(GetDepartmentById),new { id = deepartment.Id});
        }
        /// <summary xml:lang="Ar">
        /// الإستعلام عن الأقسام الموجودة
        /// </summary>
        /// <param name="query" xml:lang="Ar" >ارسال عدد الصفحات و حجمها</param>
        /// <returns xml:lang="Ar">قائمة من الأقسام الموجودة</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<DepartmentDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> DepartmentList([FromQuery] GetDepartmentListQuery query)
        {
            var result = await mediator.Send(query);
            HttpContext.Response.AddPagantionHeaders(result.metaData);
            return Ok(result.list);
        }
        /// <summary>
        /// جلب بيانات القسم من خلال رقم المعرف 
        /// </summary>
        /// <param name="id">رقم المعرف الخاص في القسم </param>
        /// <returns>يرجع بيانات القسم حيث تحتوي على الإسم و الوصف</returns>
        [HttpGet("{id}",Name = nameof(GetDepartmentById))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById([FromRoute] int id)
        {
            var result = await mediator.Send(new GetDepartmentQuery { Id = id });
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        /// <summary>
        /// استعلام عن حالة القسم 
        /// </summary>
        /// <param name="id">ارسال رمز المعرف للقسم</param>
        /// <returns>حالة القسم</returns>
        [HttpGet("{id}/Status")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LookupDto>> GetDepartmentStatusById([FromRoute] int id)
        {
            return Ok(await mediator.Send(new GetDepartmentStatusQuery { Id = id }));
        }
        [HttpPost("{id}/Status")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LookupDto>> UpdateDepartmentStatus([FromRoute] int id, [FromBody] UpdateStatusDepartmentCommand command)
        {
            command.Id = id;
            await mediator.Send(command);
            return NoContent();
        }
        /// <summary xml:lang="Ar">
        /// تحديث بيانات القسم 
        /// </summary>
        /// <remarks>
        /// sample request
        /// <example>
        /// 
        ///     Put api/Department
        ///
        ///     {
        ///         "nameArabic" : "اسم القسم بالعربي"  // required 
        ///         "nameEnglish" : "name of department in english" // required
        ///         "desceprtionArabic": "وصف القسم بالعربي",  // optoinal   
        ///         "desceprtionEnglish": "department desceprtion in english.", // optoinal
        ///     }
        ///    
        /// </example>
        /// </remarks>
        /// <param name="command"></param>
        /// <returns>returen 204 if the update succesed.</returns>
        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(FullyUpdateDepartmentCommand command)
        {
            await mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// حذف قسم 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            await mediator.Send(new DeleteDepartmetCommand() { Id = id});   
            return NoContent();
        }


    }
}
