﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DocuManage.Logic.Interfaces
{
    public interface IFileService
    {
        public Task<string> UploadFile(IFormFile file);
    }
}
