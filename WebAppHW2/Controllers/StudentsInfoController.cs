using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsInfoBusinessLayer;

namespace WebAppHW2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsInfoController : ControllerBase
    {
        private readonly IStudentsInfoService studentsInfoService;

        public StudentsInfoController(IStudentsInfoService studentsInfoService)
        {
            this.studentsInfoService = studentsInfoService;
        }

        [HttpPost]
        public Guid Post(StudentsInfo studentsInfo)
        {
            return studentsInfoService.AddStudentsInfo(studentsInfo);
        }

        [HttpGet]
        public IEnumerable<StudentsInfo> GetAll()
        {
            return studentsInfoService.GetAll();
        }

        [HttpGet("{id}")]
        public StudentsInfo GetById(Guid id)
        {
            return studentsInfoService.GetById(id);
        }

        [HttpPut]
        public bool Edit(StudentsInfo studentsInfo)
        {
            return studentsInfoService.Update(studentsInfo);
        }

        [HttpDelete("{id}")]
        public bool DeleteById(Guid id)
        {
            return studentsInfoService.RemoveStudentsInfo(id);
        }

        [HttpDelete]
        public bool DeleteAll()
        {
            return studentsInfoService.RemoveAllStudentsInfo();
        }
    }
}
