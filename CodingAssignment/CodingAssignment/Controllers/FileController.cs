using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CodingAssignment.Models;
using CodingAssignment.Services;
using CodingAssignment.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodingAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileController : ControllerBase
    {

        private FileManagerService _fileManger;

        public FileController()
        {
        }

        [HttpGet]
        public DataFileModel Get()
        {
            _fileManger = new FileManagerService();
            DataFileModel mod = _fileManger.GetData();
            return mod;
        }

        [HttpPost]
        public HttpStatusCode Post(DataModel model)
        {
            _fileManger = new FileManagerService();
            DataFileModel mod = _fileManger.GetData();
            if (model != null)
            {
                int getCount = mod.Data.Where(x => x.Id == model.Id).Count();
                if (getCount < 1)
                {
                    _fileManger.Insert(model);
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.AlreadyReported;
                }
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        [HttpPut]
        public HttpStatusCode Put(DataModel model, int id)
        {
            _fileManger = new FileManagerService();
            DataFileModel mod = _fileManger.GetData();
            if (model != null)
            {
                int getCount = mod.Data.Where(x => x.Id == id).Count();
                if (getCount > 0)
                {
                    _fileManger.Update(model, id);
                    return HttpStatusCode.OK;
                }
                else
                {
                    return HttpStatusCode.NotFound;
                }
            }
            else
            {
                return HttpStatusCode.BadRequest;
            }
        }

        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            _fileManger = new FileManagerService();
            DataFileModel mod = _fileManger.GetData();
            int getCount = mod.Data.Where(x => x.Id == id).Count();
            if (getCount > 0)
            {
                _fileManger.Delete(id);
                return HttpStatusCode.OK;
            }
            else
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}
