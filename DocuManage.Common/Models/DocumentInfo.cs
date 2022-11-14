﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuManage.Common.Models
{
    public class DocumentInfo
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
    }
}